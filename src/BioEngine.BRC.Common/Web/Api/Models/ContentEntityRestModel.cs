using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Routing;
using BioEngine.BRC.Common.Web.Api.Entities;
using Microsoft.AspNetCore.Routing;

namespace BioEngine.BRC.Common.Web.Api.Models
{
    public class ContentEntityRestModel<TEntity> : SiteEntityRestModel<TEntity> where TEntity : class, IContentEntity
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly SitesRepository _sitesRepository;
        public bool IsPublished { get; set; }
        public DateTimeOffset? DatePublished { get; set; }
        public List<PublicUrl> PublicUrls { get; set; } = new List<PublicUrl>();
        public List<ContentBlock> Blocks { get; set; } = new List<ContentBlock>();
        public string Url { get; set; }
        public string Title { get; set; }

        protected ContentEntityRestModel(LinkGenerator linkGenerator, SitesRepository sitesRepository, PropertiesProvider propertiesProvider) : base(propertiesProvider)
        {
            _linkGenerator = linkGenerator;
            _sitesRepository = sitesRepository;
        }

        protected override async Task ParseEntityAsync(TEntity entity)
        {
            await base.ParseEntityAsync(entity);
            IsPublished = entity.IsPublished;
            DatePublished = entity.DatePublished;
            var sites = await _sitesRepository.GetByIdsAsync(entity.SiteIds);
            Url = entity.Url;
            Title = entity.Title;
            foreach (var site in sites)
            {
                PublicUrls.Add(new PublicUrl {Url = _linkGenerator.GeneratePublicUrl(entity, site), Site = site});
            }

            Blocks = entity.Blocks != null
                ? entity.Blocks.OrderBy(b => b.Position).Select(ContentBlock.Create).ToList()
                : new List<ContentBlock>();
        }

        protected override async Task<TEntity> FillEntityAsync(TEntity entity)
        {
            entity = await base.FillEntityAsync(entity);
            entity.Url = Url;
            entity.Title = Title;
            return entity;
        }
    }

    public class PublicUrl
    {
        public Uri Url { get; set; }
        public Common.Entities.Site Site { get; set; }
    }
}
