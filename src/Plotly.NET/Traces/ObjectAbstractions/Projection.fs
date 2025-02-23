﻿namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices


type ProjectionDimension() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Scale: float,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =
        ProjectionDimension() |> ProjectionDimension.style (?Opacity = Opacity, ?Scale = Scale, ?Show = Show)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Opacity: float,
            [<Optional; DefaultParameterValue(null)>] ?Scale: float,
            [<Optional; DefaultParameterValue(null)>] ?Show: bool
        ) =

        fun (projectionDimension: ProjectionDimension) ->

            projectionDimension
            |> DynObj.withOptionalProperty "opacity" Opacity
            |> DynObj.withOptionalProperty "scale" Scale
            |> DynObj.withOptionalProperty "show" Show

type Projection() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?X: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Y: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Z: ProjectionDimension
        ) =
        Projection() |> Projection.style (?X = X, ?Y = Y, ?Z = Z)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?X: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Y: ProjectionDimension,
            [<Optional; DefaultParameterValue(null)>] ?Z: ProjectionDimension
        ) =

        fun (projection: Projection) ->

            projection
            |> DynObj.withOptionalProperty "x" X
            |> DynObj.withOptionalProperty "y" Y
            |> DynObj.withOptionalProperty "z" Z