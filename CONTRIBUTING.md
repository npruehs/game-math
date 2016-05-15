# Contributing

You'd like to help make GameMath even more awesome? Seems like today's our lucky day! In order to maintain stability of the library and its code base, please adhere to the following steps, and we'll be pleased to include your additions in our next release.

Note that GameMath is distributed under the [MIT License](https://github.com/npruehs/game-math/blob/develop/LICENSE). So will be your code.

## Step 1: Choose what to do

If you've got no idea how to help, head over to our [issue tracker](https://github.com/npruehs/game-math/issues) and see what you'd like to do most. You can basically pick anything you want to, as long as it's not already assigned to anyone.

If you know exactly what you're missing, [open a new issue](https://github.com/npruehs/game-math/issues/new) to begin a short discussion about your idea and how it fits the project. If we all agree, you're good to go!

## Step 2: Fork the project and check out the code

GameMath is developed using the [GitFlow branching model](http://nvie.com/posts/a-successful-git-branching-model/). In order to contribute, you should check out the latest develop branch, and create a new feature or hotfix branch to be merged back.

## Step 3: Implement your feature or bugfix

We recommend using [StyleCop](http://stylecop.codeplex.com/) for verifying your code against our [coding guidelines](https://msdn.microsoft.com/en-us/library/ff926074.aspx).

### Naming Conventions

In order to make the code more readable and consistent, contributions are required to adhere to the following guidelines:

* Vectors are denoted by _v, w, u_.
* Pairs of vectors are denoted by _v, w_ (as opposed to v0, v1).

* Points are denoted by _p, q, r, s_.
* Pairs of points are denoted by _p, q_ (as opposed to p0, p1).

* Numbers without meaning are denoted by _x, y, z_.
* Numbers with meaning are denoted by their meaning (e.g. _degrees_).

* Pairs of any other type are deonoted by _first, second_.

Exceptions to these rules are algorithms implemented based on public sources. If your implementation is based on a publication using different symbols, you should use these names in order to increase readability with respect to the original source.

## Step 4: Open a pull request

Finally, [open a pull request](https://help.github.com/articles/using-pull-requests/) so we can review your changes together, and finally integrate it into the next release.
