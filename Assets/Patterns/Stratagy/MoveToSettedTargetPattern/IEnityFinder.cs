using System.Collections.Generic;

namespace Assets.Patterns.Stratagy.Example
{
    public interface IEnityFinder
    {
        IEnumerable<Enity> Find();
    }
}