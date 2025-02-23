﻿namespace Plotly.NET.LayoutObjects

open Plotly.NET
open DynamicObj
open System
open System.Runtime.InteropServices

/// <summary></summary>
type MapboxLayerSymbol() =

    inherit DynamicObj()

    /// <summary>Initialize a MapboxLayer object</summary>

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Icon: string,
            [<Optional; DefaultParameterValue(null)>] ?IconSize: float,
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?Placement: StyleParam.MapboxLayerSymbolPlacement,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition
        ) =
        MapboxLayerSymbol()
        |> MapboxLayerSymbol.style (
            ?Icon = Icon,
            ?IconSize = IconSize,
            ?Text = Text,
            ?Placement = Placement,
            ?TextFont = TextFont,
            ?TextPosition = TextPosition
        )

    /// <summary>Create a function that applies the given style parameters to a MapboxLayer object.</summary>

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Icon: string,
            [<Optional; DefaultParameterValue(null)>] ?IconSize: float,
            [<Optional; DefaultParameterValue(null)>] ?Text: string,
            [<Optional; DefaultParameterValue(null)>] ?Placement: StyleParam.MapboxLayerSymbolPlacement,
            [<Optional; DefaultParameterValue(null)>] ?TextFont: Font,
            [<Optional; DefaultParameterValue(null)>] ?TextPosition: StyleParam.TextPosition
        ) =
        fun (mapBoxLayerSymbol: MapboxLayerSymbol) ->

            mapBoxLayerSymbol
            |> DynObj.withOptionalProperty   "icon"         Icon         
            |> DynObj.withOptionalProperty   "iconsize"     IconSize     
            |> DynObj.withOptionalProperty   "text"         Text         
            |> DynObj.withOptionalPropertyBy "placement"    Placement    StyleParam.MapboxLayerSymbolPlacement.convert
            |> DynObj.withOptionalProperty   "textfont"     TextFont     
            |> DynObj.withOptionalPropertyBy "textposition" TextPosition StyleParam.TextPosition.convert
