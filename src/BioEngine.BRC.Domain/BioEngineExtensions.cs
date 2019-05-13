using System;
using BioEngine.Core.DB;
using BioEngine.Core.Search.ElasticSearch;
using BioEngine.Core.Storage;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Domain
{
    public static class BioEngineExtensions
    {
        public static Core.BioEngine AddPostgresDb(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<PostgresDatabaseModule, PostgresDatabaseModuleConfig>(
                (configuration, env) => new PostgresDatabaseModuleConfig(configuration["BE_POSTGRES_HOST"],
                    configuration["BE_POSTGRES_USERNAME"], configuration["BE_POSTGRES_DATABASE"],
                    configuration["BE_POSTGRES_PASSWORD"], int.Parse(configuration["BE_POSTGRES_PORT"]),
                    env.IsDevelopment(), typeof(BrcDomainModule).Assembly));
        }

        public static Core.BioEngine AddElasticSearch(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<ElasticSearchModule, ElasticSearchModuleConfig>((configuration, env) =>
                new ElasticSearchModuleConfig(configuration["BE_ELASTICSEARCH_URI"],
                    configuration["BE_ELASTICSEARCH_LOGIN"], configuration["BE_ELASTICSEARCH_PASSWORD"]));
        }

        public static Core.BioEngine AddS3Storage(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<S3StorageModule, S3StorageModuleConfig>((configuration, env) =>
            {
                var uri = configuration["BE_STORAGE_PUBLIC_URI"];
                var success = Uri.TryCreate(uri, UriKind.Absolute, out var publicUri);
                if (!success)
                {
                    throw new ArgumentException($"URI {uri} is not proper URI");
                }

                var serverUriStr = configuration["BE_STORAGE_S3_SERVER_URI"];
                success = Uri.TryCreate(serverUriStr, UriKind.Absolute, out var serverUri);
                if (!success)
                {
                    throw new ArgumentException($"S3 server URI {uri} is not proper URI");
                }

                return new S3StorageModuleConfig(publicUri, serverUri, configuration["BE_STORAGE_S3_BUCKET"],
                    configuration["BE_STORAGE_S3_ACCESS_KEY"], configuration["BE_STORAGE_S3_SECRET_KEY"]);
            });
        }
    }
}