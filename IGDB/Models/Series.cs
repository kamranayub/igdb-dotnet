using System;
using Newtonsoft.Json;

namespace IGDB
{
    public class Series
    {
        public DateTimeOffset CreatedAt { get; set; }

        public int[] Games { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }
    }
}