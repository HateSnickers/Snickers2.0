using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Nastavení velikosti okna
            this.Width = 1280;
            this.Height = 720;
            // Inicializace bitmapy pro kreslení
            bm = new Bitmap(pic.Width,pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
        }
        // Deklarace proměnných a objektů
        Bitmap bm; // Bitmapa pro ukládání obrázku
        Graphics g; // Grafický objekt pro kreslení
        bool paint = false; // Ověření, že se kreslí
        Point px, py; // Předchozí a současná pozice myši
        Pen p = new Pen(Color.Black,1); // Pero pro kreslení
        Pen erase=new Pen(Color.White,10); // guma
        int index; // Index vybraného nástroje
        int x, y, sX, sY, cX, cY;  // Souřadnice myši

        ColorDialog cd = new ColorDialog(); //výběr barvy
        Color new_color;// Vybraná barva

        private void pic_MouseDown(object sender, MouseEventArgs e)   //stisknutí tlačítka myši
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;

        }



        private void pic_MouseMove(object sender, MouseEventArgs e)    //pohyb myši
        {
            if(paint)
            {
                if(index==1) // tužka
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }
                if (index == 2) //guma
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;
                }
            }
            pic.Refresh(); 

            x = e.X;
            y = e.Y;
            sX = cX - cX;
            sY = e.Y - cY;
        }

        private void pic_MouseUp(object sender, MouseEventArgs e) // uvolnění tlačítka myši
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3) // Pokud je vybraná elipsa
            {
                g.DrawEllipse(p,cX,cY,sX,sY);
            }
            if(index == 4)  // Pokud je vybraný obdélník
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if(index == 5) // Pokud je vybraná linka
            {
                g.DrawLine(p, cX, cY, x, y);
            }
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void color_picker_DoubleClick(object sender, EventArgs e)
        {
            //omyl, neumim smazat, bo mi to pak neukaze form
        }
        private void color_picker_Click(object sender, EventArgs e)
        {
            // omyl, neumim smazat, bo m ito pak naukaze form
        }

        private void btn_rect_Click(object sender, EventArgs e) //obdelnik 
        {
            index = 4;
        }


        private void btn_line_Click(object sender, EventArgs e) //linka
        {
            index = 5;
        }

        private void pic_Paint(object sender, PaintEventArgs e) // barva
        {

            Graphics g = e.Graphics;

            if (index == 3) // Ellipse
            {
                if (paint)
                {
                    int minX = Math.Min(cX, x);
                    int minY = Math.Min(cY, y);
                    int width = Math.Abs(x - cX);
                    int height = Math.Abs(y - cY);
                    g.DrawEllipse(p, minX, minY, width, height);
                }
            }
            else if (index == 4) // Rectangle
            {
                if (paint)
                {
                    int minX = Math.Min(cX, x);
                    int minY = Math.Min(cY, y);
                    int width = Math.Abs(x - cX);
                    int height = Math.Abs(y - cY);
                    g.DrawRectangle(p, minX, minY, width, height);
                }
            }
            else if (index == 5) // Line
            {
                if (paint)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }

        }

        private void btn_clear_Click(object sender, EventArgs e) //kliknutí na tlačítko Clear a reset indexu na nulu
        {
            g.Clear(Color.White);
            pic.Image = bm;
            index = 0;
        }

        private void btn_color_Click(object sender, EventArgs e) //kliknutí na tlačítko Color
        {
            //otevření dialogu barev
            cd.ShowDialog();
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            p.Color = cd.Color;
        }

        static Point set_point(PictureBox pb, Point pt) 
        {
            // Metoda pro přepočet souřadnic myši pro změřítkování s obrázkem
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX),(int)(pt.Y * pY));
        }

        private void color_picker_MouseClick(object sender, MouseEventArgs e)
        {
            // Nastavení vybrané barvy na barvu z obrázku color_picker
            Point point = set_point(color_picker, e.Location);
            pic_color.BackColor = ((Bitmap)color_picker.Image).GetPixel(point.X, point.Y);
            new_color = pic_color.BackColor;
            p.Color = pic_color.BackColor;
        }

        private void validate(Bitmap bm,Stack<Point>sp,int x, int y, Color old_color, Color new_color)
        // Metoda pro ověření souřadnic a změnu barvy pixelu
        {  
            Color cx = bm.GetPixel(x, y);
            if(cx == old_color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x,y,new_color);
            }
        }
        public void Fill(Bitmap bm, int x, int y, Color new_clr) //vyplnění plochy, prostě fill
        {
            Color old_color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, new_clr);
            if (old_color == new_clr) return;

            while(pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if(pt.X>0 &&pt.Y>0 &&pt.X<bm.Width-1 &&pt.Y<bm.Height-1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, old_color, new_color);
                    validate(bm, pixel, pt.X, pt.Y - 1, old_color, new_color);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_color);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_color);



                }
            }
        }
        private void pic_MouseClick(object sender, MouseEventArgs e) //kliknutí na pictureBox
        {
            if (index == 7)
            {
                Point point = set_point(pic, e.Location);
                Fill(bm, point.X, point.Y, new_color);
            }
        }
        private void btn_fill_Click(object sender, EventArgs e) //kliknutí na Fill
        {
            index = 7;
        }
        private void btn_save_Click(object sender, EventArgs e) //kliknutí na tlačítko Save
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) 
            {
                saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg;*.jpeg|PNG Image|*.png";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        // Uložení obrázku do souboru ve vybraném formátu
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1: // BMP
                                bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 2: // JPEG
                                bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case 3: // PNG
                                bm.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                        // Zobrazení okna po úspěšném uložení
                        MessageBox.Show("Obrázek byl úspěšně uložen.", "Uložit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Zobrazení okna při neúspěšném uložení
                        MessageBox.Show("Nastala chyba při ukládání obrázku: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_marker_Click(object sender, EventArgs e)
        {
            // omyl, neumim smazat, bo m ito pak naukaze form
        }
    }
}
