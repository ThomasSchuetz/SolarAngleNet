# SolarAngleNet

![NuGet downloads](https://img.shields.io/nuget/dt/solarangles?label=NuGet%20downloads)
![SolarAnglesNet](https://github.com/ThomasSchuetz/SolarAnglesNet/workflows/SolarAnglesNet/badge.svg?branch=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ThomasSchuetz_SolarAnglesNet&metric=alert_status)](https://sonarcloud.io/dashboard?id=ThomasSchuetz_SolarAnglesNet)

C# (.NET standard) implementation of common solar radiation models.

This package can help you determining solar angles, sunrise and sunset times as well as effective radiation on tilted surfaces. 

## Plans for future developments

- Handling of diffuse radiation
- Including clear sky models

## Installation

The simples way to obtain the package is through NuGet, by searching for ``SolarAngles`` and installing it that way.

## Usage

There are two anticipated use cases for using this package.

- Using the ``SolarAngles``-wrapper class. This is the preferred method of usage, as you can define your input format (e.g. local time or UTC or solar time) and used models.
- By accessing each component directly. This is less preferred as you are bound to use the internal data model (angles except for latitude and longitude are in radian and time is assumed to be in solar time).

### Using the ``SolarAngles``-wrapper class

Brief example of calculating the incidence angle on solar noon on Christmas Day onto a roof with 30° slope angle and west orientation in Nuremberg (Germany), while also defining the declination angle model:

```cs
var tiltedSurface = new SolarAngles.TiltedSurface(beta: 30, gamma: 90);
var nuremberg = new SolarAngles.Location(49.27, 11.05);
var solarAngles = new SolarAngles.SolarAngles(nuremberg, tiltedSurface);

var config = SolarAngles.Configuration.Config;
config.SetDeclinationAngleModel(SolarAngles.DeclinationAngle.DeclinationAngleModels.Spencer1971);

var result = solarAngles.GetIncidenceAngle(new DateTime(2020, 12, 25, 12, 0, 0));
```

## Implemented models

There are multiple models and converters that you can choose from within the ``Configuration``-class.

### Air Mass models:

- Basic model, in which Air Mass is <img src="https://render.githubusercontent.com/render/math?math=\sec{z}">, with z being the zenith angle. (default)
- Kasten and Young (1989)

### Declination Angle models:

- Cooper (1969) model (default)
- Spencer (1971) model

### Sunset Hour Angle models:

- Basic model without considering atmospheric refraction
- Model with consideration of atmospheric refraction (default)

### Definition of input and output time formats:

- UTC
- Local time without consideration of daylight-savings-time
- Local time with consideration of daylight-savings-time
- Solar time (default)

## Contributing

Please feel free to contribute to the package by either

- Writing an issue if you found bugs or if you believe that certain models / features should be added
- Integrate new features / models in a separate branch and make a pull request

## Used other open-source projects

* GeoTimeZone (release 4.1.0)
* TimeZoneConverter (release 3.3.0)
* NUnit testing framework (release 3.12.0)
* NUnit3TestAdapter (release 3.15.1)
