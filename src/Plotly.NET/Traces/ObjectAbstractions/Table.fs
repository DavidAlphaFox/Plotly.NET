﻿namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// CellColor type inherits from dynamic object
type TableFill() =
    inherit DynamicObj()

    static member init([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        TableFill() |> TableFill.style (?Color = Color)

    static member style([<Optional; DefaultParameterValue(null)>] ?Color: Color) =
        fun (fill: TableFill) ->
            fill
            |> DynObj.withOptionalProperty "color" Color

/// Cells type inherits from dynamic object
type TableCells() =
    inherit DynamicObj()

    /// Initialized Cells object
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.HorizontalAlign,
            [<Optional; DefaultParameterValue(null)>] ?MultiAlign: seq<StyleParam.HorizontalAlign>,
            [<Optional; DefaultParameterValue(null)>] ?Fill: TableFill,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Format: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Height: int,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Prefix: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiPrefix: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Suffix: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiSuffix: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#seq<#IConvertible>>
        ) =
        TableCells()
        |> TableCells.style (
            ?Align = Align,
            ?MultiAlign = MultiAlign,
            ?Fill = Fill,
            ?Font = Font,
            ?Format = Format,
            ?Height = Height,
            ?Line = Line,
            ?Prefix = Prefix,
            ?MultiPrefix = MultiPrefix,
            ?Suffix = Suffix,
            ?MultiSuffix = MultiSuffix,
            ?Values = Values
        )

    //Applies the styles to TableCells()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Align: StyleParam.HorizontalAlign,
            [<Optional; DefaultParameterValue(null)>] ?MultiAlign: seq<StyleParam.HorizontalAlign>,
            [<Optional; DefaultParameterValue(null)>] ?Fill: TableFill,
            [<Optional; DefaultParameterValue(null)>] ?Font: Font,
            [<Optional; DefaultParameterValue(null)>] ?Format: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Height: int,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Prefix: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiPrefix: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Suffix: string,
            [<Optional; DefaultParameterValue(null)>] ?MultiSuffix: seq<string>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#seq<#IConvertible>>
        ) =
        fun (cells: TableCells) ->

            cells
            |> DynObj.withOptionalSingleOrMultiPropertyBy "align" (Align, MultiAlign) StyleParam.HorizontalAlign.convert
            |> DynObj.withOptionalProperty "fill" Fill
            |> DynObj.withOptionalProperty "font" Font
            |> DynObj.withOptionalProperty "format" Format
            |> DynObj.withOptionalProperty "height" Height
            |> DynObj.withOptionalProperty "line" Line
            |> DynObj.withOptionalSingleOrMultiProperty "prefix" (Prefix, MultiPrefix)
            |> DynObj.withOptionalSingleOrMultiProperty "suffix" (Suffix, MultiSuffix)
            |> DynObj.withOptionalProperty "values" Values

type TableHeader = TableCells
