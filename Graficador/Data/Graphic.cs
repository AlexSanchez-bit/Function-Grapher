using Blazor.Extensions.Canvas;
using Blazor.Extensions.Canvas.Canvas2D;
using Blazor.Extensions;
namespace Graficador.Data
{
    public class Graphic
    {
        private BECanvasComponent canvasComponent;
        private Canvas2DContext canvas2DContext;
        private int height;
        private int width;
        private double scale;
        private double origin_x, origin_y;
        public Graphic(BECanvasComponent canvasComponent) {

            this.canvasComponent = canvasComponent;
            height = (int)canvasComponent.Height;
            width = (int)canvasComponent.Width;
            (origin_x, origin_y) = getOrigin();
        }

        private double getScale(double range_a, double range_b) {
            return (origin_x) / (Math.Max(Math.Abs(range_a), Math.Abs(range_b)));
        }
        private (double, double) getOrigin() {
            double originx = width / 2;
            double originy = height / 2;
            return (originx, originy);
        }
      
        public async Task DrawGraphic(double range_a, double range_b) {
            this.canvas2DContext = await canvasComponent.CreateCanvas2DAsync();
            scale = Math.Round(getScale(range_a, range_b),3);

            //Draw Y
            await canvas2DContext.BeginPathAsync();
            await canvas2DContext.MoveToAsync(origin_x, height);
            await canvas2DContext.LineToAsync(origin_x, 0);
            await canvas2DContext.SetStrokeStyleAsync("#000");
            await canvas2DContext.StrokeAsync();

            //Draw X
            await canvas2DContext.BeginPathAsync();
            await canvas2DContext.MoveToAsync(0, origin_y);
            await canvas2DContext.LineToAsync(width, origin_y);
            await canvas2DContext.SetStrokeStyleAsync("#000");
            await canvas2DContext.StrokeAsync();

            //draw scale
            await canvas2DContext.BeginPathAsync();
            for (int i = 0; i <= (width/2) / scale; i++)
            {
       
                await canvas2DContext.FillRectAsync(origin_x  , ( origin_y  + i*scale ) - 2.5, 5,1);
                await canvas2DContext.FillRectAsync( (origin_x + i*scale) - 0.5, origin_y, 1, 5);

                await canvas2DContext.FillRectAsync(origin_x, origin_y - i * scale, 5, 1);
                await canvas2DContext.FillRectAsync(origin_x - i * scale, origin_y, 1, 5);
            }
         


        }
        public async Task DrawFunction(List<Tuple<double,double>> values){
         
            //set style
            await canvas2DContext.BeginPathAsync();
            await canvas2DContext.SetStrokeStyleAsync("#F00");
            await canvas2DContext.MoveToAsync(origin_y, origin_y);


            for (int i = 0; i < values.Count - 1; i++)
                {
                double x_ini = origin_x +  values[i].Item1 * scale;
                double y_ini = height - (origin_y + values[i].Item2 * scale);
                double x_fin = origin_x + values[i+1].Item1 * scale;
                double y_fin = height - (origin_y + values[i+1].Item2 * scale);

                await canvas2DContext.MoveToAsync(x_ini,y_ini);
                await canvas2DContext.LineToAsync(x_fin,y_fin);
                await canvas2DContext.StrokeAsync();

            }

        }

        public async Task Clear() {
            this.canvas2DContext = await canvasComponent.CreateCanvas2DAsync();
            await canvas2DContext.ClearRectAsync(0, 0, width, height);
        
        }
    }
}
