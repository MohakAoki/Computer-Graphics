# Computer-Graphics

## A project for Computer Graphics with C#

See and learn how the lines and basic shapes are drawn with different algorithms. (currently only DDA algorithm).

## How it works?

you need a visual studio and .Net 5.

after running the project, you will see main window.
![main window](/Demo/MainWindow.png)

### Adding shape to draw
for adding shapes to draw, first you need to select what kind of shape you want to draw (currently only line with DDA algorithm works).
Then, fill the textbox of draw section.
![Write Point](/Demo/WritePoint.png)
After that you need to click Add for adding the shape to draw list. then Draw button to draw the shapes that are in Draw List
![Adding point and draw](/Demo/AddPoint%20and%20Draw.png)

You can add multiple shapes (same type or different types) to draw list. you need to click Draw every time you update the Draw List.
![Multiple Shapes](/Demo/Drawing%20Multiple%20Shapes.png)

### Changing Color
By default its going to draw all shapes in red. you can change that befor clicking Add button.
For chaning the color you should press that red square and pick the color you want.
![Color selecting](/Demo/Changing%20Color.png)
the names in the Draw List and shapes in preview will draw (render) with selected color.

### Deleting shapes
For deleting shapes first select the shape you want in Draw List then click Delete button. also you need to click Draw button again to see the preview.

### Changing panel size and pivot
You can change the size of preview or pivot. After seting new size, you should click Resize button to apply changes. by changing the size, your preview will change the size. Be carefull the draw list points should be in size if preview.
All draw shapes are base on pivot. You can simply change the pivot location by changin the numbers and then clicking Set Pivot button. by changing the pivot location, all items in draw list will redraw immediately.
![Changin pivot](/Demo/Changing%20Pivot.png)

### Other features
- Keep ratio: for keeping ratio of pivot when chaning the size of preview. if turn off, by changing size, pivot will remain at the current location.
- Live Change: if true, then no needs to click buttons. all features will work automatically (currently only size and pivot works).

## TO DO
- Completing Live Change to work with shape drawing.
- Adding thickness to draw shapes
- Handling points that are out of preview.
- Adding Bresenham Algorithm for Drawing lines.
- Adding  Circle Drawer and Eclipse Drawer.
- Completing Analyzer to analyze how shapes are drawn

## Bugs
- the location out of preview will cause error.
