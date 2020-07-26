using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Comments;
using BioEngine.BRC.Common.Components;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.IPB.Entities;
using BioEngine.BRC.Common.IPB.Publishing;
using BioEngine.BRC.Common.Users;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BioEngine.BRC.Common.IPB.Comments
{
    [UsedImplicitly]
    public class IPBCommentsProvider : BaseCommentsProvider
    {
        private readonly IPBModuleConfig _options;

        public IPBCommentsProvider(BioContext dbContext,
            ILogger<IPBCommentsProvider> logger,
            IPBModuleConfig options,
            IUserDataProvider userDataProvider)
            : base(dbContext, userDataProvider, logger)
        {
            _options = options;
        }


        protected override IQueryable<BaseComment> GetDbSet()
        {
            return DbContext.Set<IPBComment>();
        }

        [SuppressMessage("ReSharper", "RCS1198")]
        public override async Task<Dictionary<Guid, Uri?>> GetCommentsUrlAsync(IContentItem[] entities, Site site)
        {
            var types = entities.Select(e => e.GetKey()).Distinct().ToArray();
            var ids = entities.Select(e => e.Id).ToArray();

            var contentSettings = await DbContext.Set<IPBPublishRecord>()
                .Where(s => types.Contains(s.Type) && ids.Contains(s.ContentId) && s.SiteIds.Contains(site.Id))
                .ToListAsync();

            var result = new Dictionary<Guid, Uri?>();
            foreach (var entity in entities)
            {
                Uri? uri = null;
                var settings = contentSettings.FirstOrDefault(c =>
                    c.Type == entity.GetKey() && c.ContentId == entity.Id);
                if (settings?.TopicId > 0)
                {
                    uri = new Uri(
                        $"{_options.Url}topic/{settings.TopicId.ToString()}/?do=getNewComment",
                        UriKind.Absolute);
                }

                result.Add(entity.Id, uri);
            }

            return result;
        }

        public override Task<BaseComment> AddCommentAsync(IContentItem entity, string text, string authorId,
            Guid? replyTo = null)
        {
            throw new NotImplementedException();
        }

        public override Task<BaseComment> UpdateCommentAsync(IContentItem entity, Guid commentId, string text)
        {
            throw new NotImplementedException();
        }
    }
}
