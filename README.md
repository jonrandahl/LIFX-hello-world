# LIFX-hello-world
See HomeController.cs in repo.

You can use this code in a basic C# MVC project by calling from the view like:

```
@Html.ActionLink("Off", "Index", "Home", new {power = "off"}, null)
@Html.ActionLink("Red", "Index", "Home", new { colour = "red" }, null)
@Html.ActionLink("Green", "Index", "Home", new { colour = "green" }, null)
@Html.ActionLink("Blue", "Index", "Home", new { colour = "blue" }, null)
```

Where the colour passed in is any colour from the LIFX docs:
https://api.developer.lifx.com/docs/colors
