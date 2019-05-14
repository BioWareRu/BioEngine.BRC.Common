using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.Search;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace BioEngine.BRC.Domain.Search
{
    [UsedImplicitly]
    public class TopicsSearchProvider : SectionsSearchProvider<Topic>
    {
        private readonly TopicsRepository _topicsRepository;

        public TopicsSearchProvider(ISearcher searcher, ILogger<BaseSearchProvider<Topic>> logger,
            TopicsRepository topicsRepository) : base(searcher,
            logger)
        {
            _topicsRepository = topicsRepository;
        }

        protected override Task<Topic[]> GetEntitiesAsync(SearchModel[] searchModels)
        {
            var ids = searchModels.Select(s => s.Id).Distinct().ToArray();
            return _topicsRepository.GetByIdsAsync(ids);
        }
    }
}
