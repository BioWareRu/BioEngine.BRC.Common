using System;
using System.Linq;
using BioEngine.BRC.Common.Entities.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Validation
{
    public class ContentItemValidator<T> : AbstractValidator<T> where T : class, IContentItem
    {
        public ContentItemValidator(BioContext dbContext)
        {
            RuleFor(e => e.Title).NotEmpty();
            RuleFor(e => e.Url).NotEmpty();
            RuleFor(e => e.Url).CustomAsync(async (url, context, _) =>
            {
                if (context.InstanceToValidate is IContentItem contentItem && contentItem.Id != Guid.Empty)
                {
                    var count = await dbContext.Set<T>().Where(p => p.Url == url && p.Id != contentItem.Id)
                        .CountAsync();
                    if (count > 0)
                    {
                        context.AddFailure(
                            $"Url {url} already taken");
                    }
                }
            });
            // RuleFor(e => e.AuthorId).NotEmpty();
            RuleFor(e => e.Blocks).NotEmpty();
        }
    }
}
