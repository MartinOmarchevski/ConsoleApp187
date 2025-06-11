using System.Collections.Generic;
using System.Linq;

namespace SetOpsApp
{
    public static class SetOperations
    {
        // Сечение A ∩ B
        public static IEnumerable<int> Intersection(IEnumerable<int> a, IEnumerable<int> b) =>
            a.Intersect(b);

        // Обединение A ∪ B
        public static IEnumerable<int> Union(IEnumerable<int> a, IEnumerable<int> b) =>
            a.Union(b);

        // Разлика A \ B
        public static IEnumerable<int> Difference(IEnumerable<int> a, IEnumerable<int> b) =>
            a.Except(b);

        // Симетрична разлика (дизюнктен сбор) A Δ B = (A\B) ∪ (B\A)
        public static IEnumerable<int> SymmetricDifference(IEnumerable<int> a, IEnumerable<int> b) =>
            a.Except(b).Union(b.Except(a));
    }
}
