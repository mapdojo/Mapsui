using System;
using System.Diagnostics.CodeAnalysis;
using Mapsui.Styles;

namespace Mapsui.Rendering;

public interface IVectorCache
{
    [return: NotNullIfNotNull("pen")]
    T? GetOrCreatePaint<T, TPen>(TPen? pen, float opacity, Func<TPen?, float, T> toPaint)
        where T : class?;

    [return: NotNullIfNotNull("brush")]
    T? GetOrCreatePaint<T>(Brush? brush, float opacity, double rotation, Func<Brush?, float, double, ISymbolCache, T> toPaint)
        where T : class?;

    T GetOrCreatePath<T, TParam>(TParam viewport, Func<TParam, T> toSkRect);

    TPath GetOrCreatePath<TPath, TGeometry>(Viewport viewport, TGeometry geometry, float lineWidth, Func<TGeometry, Viewport, float, TPath> toPath, Func<TGeometry, TGeometry>? copy)
        where TPath : class
        where TGeometry : class;
}
