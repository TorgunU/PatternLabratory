using System.Collections.Generic;

namespace Assets.Patterns.Stratagy.Example
{
    public class NoViewPattern : IEnityFinder
    {
        public IEnumerable<Enity> Find() => null;
    }
}