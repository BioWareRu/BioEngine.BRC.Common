using System.Collections.Generic;
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
    public class DevelopersSearchProvider : SectionsSearchProvider<Developer>
    {
        private readonly DevelopersRepository _developersRepository;

        public DevelopersSearchProvider(ISearcher searcher, ILogger<BaseSearchProvider<Developer>> logger,
            DevelopersRepository developersRepository) : base(searcher,
            logger)
        {
            _developersRepository = developersRepository;
        }

        protected override async Task<IEnumerable<Developer>> GetEntitiesAsync(IEnumerable<SearchModel> searchModels)
        {
            var ids = searchModels.Select(s => s.Id).Distinct().ToArray();
            return await _developersRepository.GetByIdsAsync(ids);
        }
    }
}