# Impworks.Utils.Wpf

![AppVeyor](https://img.shields.io/appveyor/ci/impworks/Utils.Wpf.svg) ![AppVeyor Tests](https://img.shields.io/appveyor/tests/impworks/Utils.Wpf.svg) [![NuGet](https://img.shields.io/nuget/v/Impworks.Utils.Wpf.svg)](https://www.nuget.org/packages/Impworks.Utils.Wpf/) ![NuGet Downloads](https://img.shields.io/nuget/dt/Impworks.Utils.Wpf.svg)

A collection of useful helpers for WPF projects.

## Installation

To install, use the following Package Manager command:

```
PM> Install-Package Impworks.Utils.Wpf
```

## Usage

Edit your `App.xaml` to add the following:

```xaml
<Application
    ...
    xmlns:converters="clr-namespace:Impworks.Utils.Wpf.Converters;assembly=Impworks.Utils.Wpf"
    xmlns:sys="clr-namespace:System;assembly=mscorlib"
    ...
>
    <Application.Resources>
        <sys:Int32 x:Key="Zero">0</sys:Int32>
        <sys:Boolean x:Key="True">True</sys:Boolean>
        <sys:Boolean x:Key="False">False</sys:Boolean>

        <converters:BooleanInverter x:Key="InvertBool" />
        <converters:BoolToVisibilityConverter x:Key="ShowIfTrue" />
        <converters:BoolToVisibilityConverter x:Key="ShowIfFalse" IsInverted="True" />
        <converters:CompareToArgumentConverter x:Key="IsNull" Argument="{x:Null}" />
        <converters:CompareToArgumentConverter x:Key="IsNotNull" Argument="{x:Null}" IsInverted="True" />
        <converters:CompareToArgumentConverter x:Key="IsZero" Argument="{StaticResource Zero}" />
        <converters:CompareToArgumentConverter x:Key="IsNotZero" Argument="{StaticResource Zero}" IsInverted="True" />
        <converters:CompositeConverter x:Key="ShowIfNull">
            <converters:CompareToArgumentConverter Argument="{x:Null}" />
            <converters:BoolToVisibilityConverter />
        </converters:CompositeConverter>
        <converters:CompositeConverter x:Key="ShowIfNotNull">
            <converters:CompareToArgumentConverter Argument="{x:Null}" IsInverted="True" />
            <converters:BoolToVisibilityConverter />
        </converters:CompositeConverter>
        <converters:CompositeConverter x:Key="ShowIfZero">
            <converters:CompareToArgumentConverter Argument="{StaticResource Zero}" />
            <converters:BoolToVisibilityConverter />
        </converters:CompositeConverter>
        <converters:CompositeConverter x:Key="ShowIfNotZero">
            <converters:CompareToArgumentConverter Argument="{StaticResource Zero}" IsInverted="True" />
            <converters:BoolToVisibilityConverter />
        </converters:CompositeConverter>
        <converters:EqualityConverter x:Key="AllEqual" />
        <converters:EqualityConverter x:Key="AllNotEqual" IsInverted="True" />

        ...
    </Application.Resources>
</Application>
```

Now you can use the converters in bindings:

```xaml
<TextBlock Text="Hello!" Visibility="{Binding ShowHello, Converter={StaticResource ShowIfTrue}}"
```