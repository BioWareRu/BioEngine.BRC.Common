﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Sitko.Core.Storage;

namespace BioEngine.BRC.Common.Extensions
{
    public static class StorageExtensions
    {
        public static Uri ThumbnailUri(this IStorage<BRCStorageConfig> storage, StorageItem storageItem, int width,
            int height)
        {
            var uri = storage.PublicUri(storageItem);
            var uriBuilder = new UriBuilder(uri);
            var query = QueryHelpers.ParseQuery(uri.Query) ?? new Dictionary<string, StringValues>();
            query["width"] = width.ToString();
            query["height"] = height.ToString();
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri;
        }
        
        public static Uri SmallThumbnailUri(this IStorage<BRCStorageConfig> storage, StorageItem storageItem)
        {
            return storage.ThumbnailUri(storageItem, 100, 100);
        }
        
        public static Uri MediumThumbnailUri(this IStorage<BRCStorageConfig> storage, StorageItem storageItem)
        {
            return storage.ThumbnailUri(storageItem, 300, 300);
        }
        
        public static Uri LargeThumbnailUri(this IStorage<BRCStorageConfig> storage, StorageItem storageItem)
        {
            return storage.ThumbnailUri(storageItem, 800, 578);
        }
    }
}
