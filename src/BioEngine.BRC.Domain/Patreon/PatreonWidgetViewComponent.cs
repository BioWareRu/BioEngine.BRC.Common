using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioEngine.BRC.Domain.Patreon
{
    public class PatreonWidgetViewComponent : ViewComponent
    {
        private readonly PatreonApiHelper _patreonApiHelper;
        private readonly ILogger<PatreonApiHelper> _logger;

        public PatreonWidgetViewComponent(PatreonApiHelper patreonApiHelper,
            ILogger<PatreonApiHelper> logger)
        {
            _patreonApiHelper = patreonApiHelper;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentGoal = new PatreonGoal();
            try
            {
                currentGoal = await _patreonApiHelper.GetCurrentGoalAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while loading patreon goals: {ex.Message}");
            }

            return View(currentGoal);
        }
    }
}
