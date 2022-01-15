using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Orion.Mapping
{
    public static class MappingProfileRegistry
    {
        public static void Configure()
        {
            Mapper.Initialize(x => GetConfiguration(Mapper.Configuration));
        }

        private static void GetConfiguration(IConfiguration configuration)
        {
            var profiles = typeof(MappingProfile).Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }
    }
}
