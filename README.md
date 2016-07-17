# GameMath

GameMath is a small, free open-source math library for games.

We aim to provide to most useful common math routines you need in games, without over-engineering or trying to be overly scientific.

If you're missing anything, we'd love to see it - please refer to the [Contributing](https://github.com/npruehs/game-math/blob/develop/CONTRIBUTING.md) file!

## Features

* Extensive vector structs for ints and floats (e.g. Vector2I, Vector3F)
* Basic geometric shapes (e.g. RectangleF, LineF)
* Intersection tests (e.g. line-line, line-circle)
* Angle operations (e.g. angle difference, angle between vectors)
* Interpolation (e.g. linear, sinusoidal, smoothstep)
* Advanced operations (e.g. Bresenham, ballistic trajectory)
* Pseudo-random number generators
* Utility methods (e.g. rounding and casting to int)
* Unit tests and references for non-trivial operations
* Public [API documentation](http://npruehs.de/game-math/api/1.0)

## Getting GameMath

You can either

* download BINARIES from the [Releases](https://github.com/npruehs/game-math/releases) page
* checkout SOURCES from this repository

## Usage

Just import the `GameMath` namespace and you're good to go!

    using GameMath;

To get an overview of the library, take a glimpse at the [API documentation](http://npruehs.de/game-math/api/1.0).
	
## Remarks

We don't want to impose any kind of coordinate system or origin on your implementation. Thus, we are avoiding property namings like "Right" or "Front", and use "MaxX" or "MaxZ" instead.

For each of our non-trivial implementations, we provide unit tests and references to algorithms. If anything's unclear, feel free to contact us. We'd love to improve our documentation.

## Development Cycle

We know that using a library like GameMath in production requires you to be completely sure about stability and compatibility. Thus, new releases of GameMath are created using [Semantic Versioning](http://semver.org/). In short:

* Version numbers are specified as MAJOR.MINOR.PATCH.
* MAJOR version increases indicate incompatible changes with respect to the public GameMath API.
* MINOR version increases indicate new functionality that are backwards-compatible.
* PATCH version increases indicate backwards-compatible bug fixes.

## Bugs & Feature Requests

We are sorry that you've experienced issues or are missing a feature! After verifying that you are using the [latest version](https://github.com/npruehs/game-math/releases) of GameMath and having checked whether a [similar issue](https://github.com/npruehs/game-math/issues) has already been reported, feel free to [open a new issue](https://github.com/npruehs/game-math/issues/new). In order to help us resolving your problem as fast as possible, please include the following details in your report:

* Steps to reproduce
* What happened?
* What did you expect to happen?

After being able to reproduce the issue, we'll look into fixing it immediately.

## Contributors

(in alphabetical order)

* [Paul Bourke](http://paulbourke.net)
* [Jeff G. Erickson](http://algorithms.wtf)
* [Darel Rex Finley](http://alienryderflex.com)
* [Christian Oeing](https://github.com/coeing)
* [Nick Prühs](https://github.com/npruehs) (Maintainer)
* [Heiner Schmidt](https://github.com/heinerschmidt)
* [Martijn Segers](https://nl.linkedin.com/in/martijn-segers-b3096956)

A warm thank you to everyone participating in this project in any way! Sometimes, math is complicated. You show that it doesn't need to be.

## License

GameMath is released under the [MIT license](https://github.com/npruehs/game-math/blob/develop/LICENSE).
