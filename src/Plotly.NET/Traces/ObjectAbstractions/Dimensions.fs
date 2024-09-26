namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Dimensions type inherits from dynamic object
type Dimension() =
    inherit DynamicObj()

    /// Initializes dimensions object to be used with parcats and parcoords plots
    static member initParallel
        (
            [<Optional; DefaultParameterValue(null)>] ?ConstraintRange: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?Label: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?MultiSelect: bool,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?TickFormat: StyleParam.TickMode,
            [<Optional; DefaultParameterValue(null)>] ?TickText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Tickvals: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        Dimension()
        |> Dimension.style (
            ?ConstraintRange = ConstraintRange,
            ?Label = Label,
            ?MultiSelect = MultiSelect,
            ?Name = Name,
            ?Range = Range,
            ?TemplateItemName = TemplateItemName,
            ?TickFormat = TickFormat,
            ?TickText = TickText,
            ?Tickvals = Tickvals,
            ?Values = Values,
            ?Visible = Visible

        )


    /// Initializes dimensions object to be used with SPLOM plots
    static member initSplom
        (
            [<Optional; DefaultParameterValue(null)>] ?AxisMatches: bool,
            [<Optional; DefaultParameterValue(null)>] ?AxisType: StyleParam.AxisType,
            [<Optional; DefaultParameterValue(null)>] ?Label: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        Dimension()
        |> Dimension.style (
            ?AxisMatches = AxisMatches,
            ?AxisType = AxisType,
            ?Label = Label,
            ?Name = Name,
            ?TemplateItemName = TemplateItemName,
            ?Values = Values,
            ?Visible = Visible

        )


    // Applies the styles to Dimensions()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Label: #IConvertible,
            [<Optional; DefaultParameterValue(null)>] ?Name: string,
            [<Optional; DefaultParameterValue(null)>] ?TemplateItemName: string,
            [<Optional; DefaultParameterValue(null)>] ?Values: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool,
            [<Optional; DefaultParameterValue(null)>] ?ConstraintRange: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?MultiSelect: bool,
            [<Optional; DefaultParameterValue(null)>] ?Range: StyleParam.Range,
            [<Optional; DefaultParameterValue(null)>] ?TickFormat: StyleParam.TickMode,
            [<Optional; DefaultParameterValue(null)>] ?TickText: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?Tickvals: seq<#IConvertible>,
            [<Optional; DefaultParameterValue(null)>] ?AxisMatches: bool,
            [<Optional; DefaultParameterValue(null)>] ?AxisType: StyleParam.AxisType
        ) =
        (fun (dims: Dimension) ->

            let axis =
                LinearAxis.init (?AxisType = AxisType)

            AxisMatches |> DynObj.setOptionalProperty axis "matches"

            Label |> DynObj.setOptionalProperty dims "label"
            Name |> DynObj.setOptionalProperty dims "name"
            TemplateItemName |> DynObj.setOptionalProperty dims "templateitemname"
            Values |> DynObj.setOptionalProperty dims "values"
            Visible |> DynObj.setOptionalProperty dims "visible"
            ConstraintRange |> DynObj.setOptionalPropertyBy dims "constraintrange" StyleParam.Range.convert
            MultiSelect |> DynObj.setOptionalProperty dims "multiselect"
            Range |> DynObj.setOptionalPropertyBy dims "range" StyleParam.Range.convert
            TickFormat |> DynObj.setOptionalPropertyBy dims "tickformat" StyleParam.TickMode.convert
            TickText |> DynObj.setOptionalProperty dims "ticktext"
            Tickvals |> DynObj.setOptionalProperty dims "tickvals"
            axis |> DynObj.withProperty dims "axis"

            dims)
