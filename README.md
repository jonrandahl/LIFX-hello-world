# LIFX-hello-world
See HomeController.cs in repo.

You can use this code in a basic C# MVC project by calling from the view like:
@Html.ActionLink("Red", "Index", "Home", new { colour = "red" }, null)

Where the colour passed in is any colour from the LIFX docs:
https://api.developer.lifx.com/docs/colors
