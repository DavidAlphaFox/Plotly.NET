﻿namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices


/// <summary>Angular axes can be used as a scale for the angular coordinates in polar plots.</summary>
type ImaginaryAxis() =
    inherit DynamicObj()

    /// <summary>
    /// Initialize an ImaginaryAxis object that can be used as a imaginary scale for smith coordinates.
    /// </summary>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
    /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="LabelAlias">Replacement text for specific tick or hover labels. For example using {US: 'USA', CA: 'Canada'} changes US to USA and CA to Canada. The labels we would have shown must match the keys exactly, after adding any tickprefix or ticksuffix. labelalias can be used with any axis type, and both keys (if needed) and values (if desired) can include html-like tags or MathJax.</param>
    /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickSuffix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="ShowTickPrefix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickFont">Sets the tick font.</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Defaults to `realaxis.tickvals` plus the same as negatives and zero.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?GridColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?GridDash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?GridWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?HoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?LabelAlias: DynamicObj,
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?ShowGrid: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowTickLabels: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowTickSuffix: StyleParam.ShowTickOption,
            [<Optional; DefaultParameterValue(null)>] ?ShowTickPrefix: StyleParam.ShowTickOption,
            [<Optional; DefaultParameterValue(null)>] ?TickColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?TickFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TickFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?TickLen: int,
            [<Optional; DefaultParameterValue(null)>] ?TickPrefix: string,
            [<Optional; DefaultParameterValue(null)>] ?Ticks: StyleParam.TickLabelPosition,
            [<Optional; DefaultParameterValue(null)>] ?TickSuffix: string,
            [<Optional; DefaultParameterValue(null)>] ?TickVals: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TickWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        ImaginaryAxis()
        |> ImaginaryAxis.style (
            ?Color = Color,
            ?GridColor = GridColor,
            ?GridDash = GridDash,
            ?GridWidth = GridWidth,
            ?HoverFormat = HoverFormat,
            ?LabelAlias = LabelAlias,
            ?Layer = Layer,
            ?LineColor = LineColor,
            ?LineWidth = LineWidth,
            ?ShowGrid = ShowGrid,
            ?ShowLine = ShowLine,
            ?ShowTickLabels = ShowTickLabels,
            ?ShowTickSuffix = ShowTickSuffix,
            ?ShowTickPrefix = ShowTickPrefix,
            ?TickColor = TickColor,
            ?TickFont = TickFont,
            ?TickFormat = TickFormat,
            ?TickLen = TickLen,
            ?TickPrefix = TickPrefix,
            ?Ticks = Ticks,
            ?TickSuffix = TickSuffix,
            ?TickVals = TickVals,
            ?TickWidth = TickWidth,
            ?Visible = Visible

        )

    /// <summary>
    /// Creates a function that applies the given style parameters to a ImaginaryAxis object
    /// </summary>
    /// <param name="Color">Sets default for all colors associated with this axis all at once: line, font, tick, and grid colors. Grid color is lightened by blending this with the plot background Individual pieces can override this.</param>
    /// <param name="GridColor">Sets the color of the grid lines.</param>
    /// <param name="GridDash">Sets the dash style of lines. Set to a dash type string ("solid", "dot", "dash", "longdash", "dashdot", or "longdashdot") or a dash length list in px (eg "5px,10px,2px,2px").</param>
    /// <param name="GridWidth">Sets the width (in px) of the grid lines.</param>
    /// <param name="HoverFormat">Sets the hover text formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="LabelAlias">Replacement text for specific tick or hover labels. For example using {US: 'USA', CA: 'Canada'} changes US to USA and CA to Canada. The labels we would have shown must match the keys exactly, after adding any tickprefix or ticksuffix. labelalias can be used with any axis type, and both keys (if needed) and values (if desired) can include html-like tags or MathJax.</param>
    /// <param name="Layer">Sets the layer on which this axis is displayed. If "above traces", this axis is displayed above all the subplot's traces If "below traces", this axis is displayed below all the subplot's traces, but above the grid lines. Useful when used together with scatter-like traces with `cliponaxis` set to "false" to show markers and/or text nodes above this axis.</param>
    /// <param name="LineColor">Sets the axis line color.</param>
    /// <param name="LineWidth">Sets the width (in px) of the axis line.</param>
    /// <param name="ShowGrid">Determines whether or not grid lines are drawn. If "true", the grid lines are drawn at every tick mark.</param>
    /// <param name="ShowLine">Determines whether or not a line bounding this axis is drawn.</param>
    /// <param name="ShowTickLabels">Determines whether or not the tick labels are drawn.</param>
    /// <param name="ShowTickSuffix">If "all", all tick labels are displayed with a prefix. If "first", only the first tick is displayed with a prefix. If "last", only the last tick is displayed with a suffix. If "none", tick prefixes are hidden.</param>
    /// <param name="ShowTickPrefix">Same as `showtickprefix` but for tick suffixes.</param>
    /// <param name="TickColor">Sets the tick color.</param>
    /// <param name="TickFont">Sets the tick font.</param>
    /// <param name="TickFormat">Sets the tick label formatting rule using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"</param>
    /// <param name="TickLen">Sets the tick length (in px).</param>
    /// <param name="TickPrefix">Sets a tick label prefix.</param>
    /// <param name="Ticks">Determines whether ticks are drawn or not. If "", this axis' ticks are not drawn. If "outside" ("inside"), this axis' are drawn outside (inside) the axis lines.</param>
    /// <param name="TickSuffix">Sets a tick label suffix.</param>
    /// <param name="TickVals">Sets the values at which ticks on this axis appear. Defaults to `realaxis.tickvals` plus the same as negatives and zero.</param>
    /// <param name="TickWidth">Sets the tick width (in px).</param>
    /// <param name="Visible">A single toggle to hide the axis while preserving interaction like dragging. Default is true when a cheater plot is present on the axis, otherwise false</param>
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?GridColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?GridDash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?GridWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?HoverFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?LabelAlias: DynamicObj,
            [<Optional; DefaultParameterValue(null)>] ?Layer: StyleParam.Layer,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?ShowGrid: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowLine: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowTickLabels: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowTickSuffix: StyleParam.ShowTickOption,
            [<Optional; DefaultParameterValue(null)>] ?ShowTickPrefix: StyleParam.ShowTickOption,
            [<Optional; DefaultParameterValue(null)>] ?TickColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?TickFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TickFormat: string,
            [<Optional; DefaultParameterValue(null)>] ?TickLen: int,
            [<Optional; DefaultParameterValue(null)>] ?TickPrefix: string,
            [<Optional; DefaultParameterValue(null)>] ?Ticks: StyleParam.TickLabelPosition,
            [<Optional; DefaultParameterValue(null)>] ?TickSuffix: string,
            [<Optional; DefaultParameterValue(null)>] ?TickVals: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?TickWidth: int,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        fun (imaginaryAxis: ImaginaryAxis) ->

            Color |> DynObj.setOptionalProperty imaginaryAxis "color"
            GridColor |> DynObj.setOptionalProperty imaginaryAxis "gridcolor"
            GridDash |> DynObj.setOptionalPropertyBy imaginaryAxis "griddash" StyleParam.DrawingStyle.convert
            GridWidth |> DynObj.setOptionalProperty imaginaryAxis "gridwidth"
            HoverFormat |> DynObj.setOptionalProperty imaginaryAxis "hoverformat"
            LabelAlias |> DynObj.setOptionalProperty imaginaryAxis "labelalias"
            Layer |> DynObj.setOptionalPropertyBy imaginaryAxis "layer" StyleParam.Layer.convert
            LineColor |> DynObj.setOptionalProperty imaginaryAxis "linecolor"
            LineWidth |> DynObj.setOptionalProperty imaginaryAxis "linewidth"
            ShowGrid |> DynObj.setOptionalProperty imaginaryAxis "showgrid"
            ShowLine |> DynObj.setOptionalProperty imaginaryAxis "showline"
            ShowTickLabels |> DynObj.setOptionalProperty imaginaryAxis "showticklabels"
            ShowTickSuffix |> DynObj.setOptionalPropertyBy imaginaryAxis "showticksuffix" StyleParam.ShowTickOption.convert
            ShowTickPrefix |> DynObj.setOptionalPropertyBy imaginaryAxis "showtickprefix" StyleParam.ShowTickOption.convert
            TickColor |> DynObj.setOptionalProperty imaginaryAxis "tickcolor"
            TickFont |> DynObj.setOptionalProperty imaginaryAxis "tickfont"
            TickFormat |> DynObj.setOptionalProperty imaginaryAxis "tickformat"
            TickLen |> DynObj.setOptionalProperty imaginaryAxis "ticklen"
            TickPrefix |> DynObj.setOptionalProperty imaginaryAxis "tickprefix"
            Ticks |> DynObj.setOptionalPropertyBy imaginaryAxis "ticks" StyleParam.TickLabelPosition.convert
            TickSuffix |> DynObj.setOptionalProperty imaginaryAxis "ticksuffix"
            TickVals |> DynObj.setOptionalProperty imaginaryAxis "tickvals"
            TickWidth |> DynObj.setOptionalProperty imaginaryAxis "tickwidth"
            Visible |> DynObj.setOptionalProperty imaginaryAxis "visible"

            imaginaryAxis
