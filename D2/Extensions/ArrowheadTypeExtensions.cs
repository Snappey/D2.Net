using System;
using D2.Enums;

namespace D2.Extensions
{
    public static class ArrowheadTypeExtensions
    {
        public static string ToCatalog(this ArrowheadType type) => type switch
        {
            ArrowheadType.Triangle => "triangle",
            ArrowheadType.Arrow => "arrow",
            ArrowheadType.Diamond => "diamond",
            ArrowheadType.Circle => "circle",
            ArrowheadType.CrowsFootOne => "cf-one",
            ArrowheadType.CrowsFootMany => "cf-many",
            ArrowheadType.CrowsFootOneRequired => "cf-one-required",
            ArrowheadType.CrowsFootManyRequired => "cf-many-required",
            _ => throw new ArgumentException("ArrowheadType does not have a catalog format", nameof(type), null)
        };
    }
}