using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Jigsaw_Puzzle
{
    public partial class Form1 : Form
    {
        //// GLOBAL VARIABLES        
        public int hints = 3;
        public string current_Tag;
        public int timeMIN, timeSEC, timeCSEC;
        public bool timerIsActive,gameIsStarted;
        public pictureHint hint = new pictureHint();
        public frmTrophies FrmTrophies;
        public string directory = @"C:\Users\asads\source\repos\Jigsaw_Puzzle\Jigsaw_Puzzle\Resources";
        public int current_Completion_Time=0;

        public Form1()
        {
            InitializeComponent();
        }
        
        public bool checkWin()
        {
            if ((String)this.pb1.Tag != "Piece1") return false;
            else if ((String)this.pb2.Tag != "Piece2") return false;
            else if ((String)this.pb3.Tag != "Piece3") return false;
            else if ((String)this.pb4.Tag != "Piece4") return false;
            else if ((String)this.pb5.Tag != "Piece5") return false;
            else if ((String)this.pb6.Tag != "Piece6") return false;
            else if ((String)this.pb7.Tag != "Piece7") return false;
            else if ((String)this.pb8.Tag != "Piece8") return false;
            else if ((String)this.pb9.Tag != "Piece9") return false;
            else if ((String)this.pb10.Tag != "Piece10") return false;
            else if ((String)this.pb11.Tag != "Piece11") return false;
            else if ((String)this.pb12.Tag != "Piece12") return false;
            else if ((String)this.pb13.Tag != "Piece13") return false;
            else if ((String)this.pb14.Tag != "Piece14") return false;
            else if ((String)this.pb15.Tag != "Piece15") return false;
            else if ((String)this.pb16.Tag != "Piece16") return false;
            else
            return true;
        }
        public void PictureBoxSizeAdjustment(){
        
            this.pbInitial01.Size = new System.Drawing.Size(125, 125);
            this.pbInitial02.Size = new System.Drawing.Size(125, 125);
            this.pbInitial03.Size = new System.Drawing.Size(125, 125);
            this.pbInitial04.Size = new System.Drawing.Size(125, 125);
            this.pbInitial05.Size = new System.Drawing.Size(125, 125);
            this.pbInitial06.Size = new System.Drawing.Size(125, 125);
            this.pbInitial07.Size = new System.Drawing.Size(125, 125);
            this.pbInitial08.Size = new System.Drawing.Size(125, 125);
            this.pbInitial09.Size = new System.Drawing.Size(125, 125);
            this.pbInitial10.Size = new System.Drawing.Size(125, 125);
            this.pbInitial11.Size = new System.Drawing.Size(125, 125);
            this.pbInitial12.Size = new System.Drawing.Size(125, 125);
            this.pbInitial13.Size = new System.Drawing.Size(125, 125);
            this.pbInitial14.Size = new System.Drawing.Size(125, 125);
            this.pbInitial15.Size = new System.Drawing.Size(125, 125);
            this.pbInitial16.Size = new System.Drawing.Size(125, 125);
        }
        public void puzzle_01_Image_Placement(){
            try
            {   this.pbInitial01.ImageLocation = directory + @"\Piece6.png";
                this.pbInitial02.ImageLocation = directory + @"\Piece12.png";
                this.pbInitial03.ImageLocation = directory + @"\Piece1.png";
                this.pbInitial04.ImageLocation = directory + @"\Piece16.png";
                this.pbInitial05.ImageLocation = directory + @"\Piece5.png";
                this.pbInitial06.ImageLocation = directory + @"\Piece11.png";
                this.pbInitial07.ImageLocation = directory + @"\Piece8.png";
                this.pbInitial08.ImageLocation = directory + @"\Piece13.png";
                this.pbInitial09.ImageLocation = directory + @"\Piece3.png";
                this.pbInitial10.ImageLocation = directory + @"\Piece15.png";
                this.pbInitial11.ImageLocation = directory + @"\Piece9.png";
                this.pbInitial12.ImageLocation = directory + @"\Piece2.png";
                this.pbInitial13.ImageLocation = directory + @"\Piece7.png";
                this.pbInitial14.ImageLocation = directory + @"\Piece4.png";
                this.pbInitial15.ImageLocation = directory + @"\Piece10.png";
                this.pbInitial16.ImageLocation = directory + @"\Piece14.png";
            }
            catch(Exception exc){
                Label errorLabel = new Label();
                errorLabel.Text = "Pictures Not Found...";
                this.Controls.Add(errorLabel);
            }
        }
        public void allowDrop_to_all_PictureBoxes(){
            this.pb1.AllowDrop = true;
            this.pb2.AllowDrop = true;
            this.pb3.AllowDrop = true;
            this.pb4.AllowDrop = true;
            this.pb5.AllowDrop = true;
            this.pb6.AllowDrop = true;
            this.pb7.AllowDrop = true;
            this.pb8.AllowDrop = true;
            this.pb9.AllowDrop = true;
            this.pb10.AllowDrop = true;
            this.pb11.AllowDrop = true;
            this.pb12.AllowDrop = true;
            this.pb13.AllowDrop = true;
            this.pb14.AllowDrop = true;
            this.pb15.AllowDrop = true;
            this.pb16.AllowDrop = true;
            this.pbInitial01.AllowDrop = true;
            this.pbInitial02.AllowDrop = true;
            this.pbInitial03.AllowDrop = true;
            this.pbInitial04.AllowDrop = true;
            this.pbInitial05.AllowDrop = true;
            this.pbInitial06.AllowDrop = true;
            this.pbInitial07.AllowDrop = true;
            this.pbInitial08.AllowDrop = true;
            this.pbInitial09.AllowDrop = true;
            this.pbInitial10.AllowDrop = true;
            this.pbInitial11.AllowDrop = true;
            this.pbInitial12.AllowDrop = true;
            this.pbInitial13.AllowDrop = true;
            this.pbInitial14.AllowDrop = true;
            this.pbInitial15.AllowDrop = true;
            this.pbInitial16.AllowDrop = true;
        }
        public void start_Game()
        {
            hints = 3;
            this.btnShowCompletePicture.Text = "Show Picture Hints left: "+hints;
            if (DialogResult.Cancel == MessageBox.Show("Are you Ready?", "Start Game", MessageBoxButtons.OKCancel))
            {
                gameIsStarted = false;
                return;
            }            
            gameIsStarted = true;
            reset_Game();
            reset_Timer();
            start_Timer();
        }
        public void clear_Game_Screen()
        {
            this.pb1.Image = null;
            this.pb2.Image = null;
            this.pb3.Image = null;
            this.pb4.Image = null;
            this.pb5.Image = null;
            this.pb6.Image = null;
            this.pb7.Image = null;
            this.pb8.Image = null;
            this.pb9.Image = null;
            this.pb10.Image = null;
            this.pb11.Image = null;
            this.pb12.Image = null;
            this.pb13.Image = null;
            this.pb14.Image = null;
            this.pb15.Image = null;
            this.pb16.Image = null;
            this.pbInitial01.Image = null;
            this.pbInitial02.Image = null;
            this.pbInitial03.Image = null;
            this.pbInitial04.Image = null;
            this.pbInitial05.Image = null;
            this.pbInitial06.Image = null;
            this.pbInitial07.Image = null;
            this.pbInitial08.Image = null;
            this.pbInitial09.Image = null;
            this.pbInitial10.Image = null;
            this.pbInitial11.Image = null;
            this.pbInitial12.Image = null;
            this.pbInitial13.Image = null;
            this.pbInitial14.Image = null;
            this.pbInitial15.Image = null;
            this.pbInitial16.Image = null;
        }
        public void reset_Game()
        {
            this.pb1.Image = null;
            this.pb2.Image = null;
            this.pb3.Image = null;
            this.pb4.Image = null;
            this.pb5.Image = null;
            this.pb6.Image = null;
            this.pb7.Image = null;
            this.pb8.Image = null;
            this.pb9.Image = null;
            this.pb10.Image = null;
            this.pb11.Image = null;
            this.pb12.Image = null;
            this.pb13.Image = null;
            this.pb14.Image = null;
            this.pb15.Image = null;
            this.pb16.Image = null;
            this.puzzle_01_Image_Placement();
        }
        public void reset_Timer()
        {
            timeMIN = 2;
            timeSEC = 0;
            timeCSEC = 0;
            this.timeMin.Text = "2:";
            this.timeSec.Text = "0:";
            this.timeCSec.Text = "0";
        }
        public void start_Timer()
        {
            timerIsActive = true;
            this.timer1.Start();
            this.btnPause.Enabled = true;
        }
        public void stop_Timer()
        {
            timerIsActive = false;
            this.timer1.Stop();
            this.btnPause.Enabled = false;
        }
        public void show_Win_MessageBox()
        {
            this.stop_Timer();
            MessageBox.Show("Congradulation!\nYou did it...");
            saveTrophies_to_Database();
        }
        public string checkTag()
        {
            if (current_Tag == this.pbInitial01.ImageLocation)
            {
                return "Piece6";
            }
            else if (current_Tag == this.pbInitial02.ImageLocation)
            {
                return "Piece12";
            }
            else if (current_Tag == this.pbInitial03.ImageLocation)
            {
                return "Piece1";
            }
            else if (current_Tag == this.pbInitial04.ImageLocation)
            {
                return "Piece16";
            }
            else if (current_Tag == this.pbInitial05.ImageLocation)
            {
                return "Piece5";
            }
            else if (current_Tag == this.pbInitial06.ImageLocation)
            {
                return "Piece11";
            }
            else if (current_Tag == this.pbInitial07.ImageLocation)
            {
                return "Piece8";
            }
            else if (current_Tag == this.pbInitial08.ImageLocation)
            {
                return "Piece13";
            }
            else if (current_Tag == this.pbInitial09.ImageLocation)
            {
                return "Piece3";
            }
            else if (current_Tag == this.pbInitial10.ImageLocation)
            {
                return "Piece15";
            }
            else if (current_Tag == this.pbInitial11.ImageLocation)
            {
                return "Piece9";
            }
            else if (current_Tag == this.pbInitial12.ImageLocation)
            {
                return "Piece2";
            }
            else if (current_Tag == this.pbInitial13.ImageLocation)
            {
                return "Piece7";
            }
            else if (current_Tag == this.pbInitial14.ImageLocation)
            {
                return "Piece4";
            }
            else if (current_Tag == this.pbInitial15.ImageLocation)
            {
                return "Piece10";
            }
            else if (current_Tag == this.pbInitial16.ImageLocation)
            {
                return "Piece14";
            }
            else return "";
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.PictureBoxSizeAdjustment();
            this.allowDrop_to_all_PictureBoxes();
            this.start_Game();

        }
        
        ///////////////////////////////////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pbInitial01.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial01.Image = img;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pbInitial02.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial02.Image = img;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Image img = pbInitial03.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial03.Image = img;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Image img = pbInitial04.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial04.Image = img;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Image img = pbInitial05.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial05.Image = img;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Image img = pbInitial06.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial06.Image = img;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Image img = pbInitial07.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial07.Image = img;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Image img = pbInitial08.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial08.Image = img;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Image img = pbInitial09.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial09.Image = img;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Image img = pbInitial10.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial10.Image = img;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Image img = pbInitial11.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial11.Image = img;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Image img = pbInitial12.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial12.Image = img;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Image img = pbInitial13.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial13.Image = img;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Image img = pbInitial14.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial14.Image = img;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Image img = pbInitial15.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial15.Image = img;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            Image img = pbInitial16.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbInitial16.Image = img;
        }

        private void pbInitial01_DragEnter(object sender, DragEventArgs e)
        {
            
            e.Effect = DragDropEffects.Copy;
        }
        private void pbInitial02_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void pbInitial03_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial04_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void pbInitial05_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void pbInitial06_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void pbInitial07_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial08_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial09_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial10_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial11_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial12_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial13_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial14_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial15_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void pbInitial16_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }

        private void pbInitial01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pbInitial01.DoDragDrop(pbInitial01.Image, DragDropEffects.Copy);
            }
        }
        private void pbInitial02_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pbInitial02.DoDragDrop(pbInitial02.Image, DragDropEffects.Copy);
            }
        }
        private void pbInitial03_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial03.DoDragDrop(pbInitial03.Image, DragDropEffects.Copy);
           
        }
        private void pbInitial04_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial04.DoDragDrop(pbInitial04.Image, DragDropEffects.Copy);
          
        }
        private void pbInitial05_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial05.DoDragDrop(pbInitial05.Image, DragDropEffects.Copy);
        }
        private void pbInitial06_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial06.DoDragDrop(pbInitial06.Image, DragDropEffects.Copy);
        }
        private void pbInitial07_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial07.DoDragDrop(pbInitial07.Image, DragDropEffects.Copy);
        }
        private void pbInitial08_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial08.DoDragDrop(pbInitial08.Image, DragDropEffects.Copy);
        }
        private void pbInitial09_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial09.DoDragDrop(pbInitial09.Image, DragDropEffects.Copy);
        }
        private void pbInitial10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial10.DoDragDrop(pbInitial10.Image, DragDropEffects.Copy);
        }
        private void pbInitial11_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial11.DoDragDrop(pbInitial11.Image, DragDropEffects.Copy);
        }
        private void pbInitial12_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial12.DoDragDrop(pbInitial12.Image, DragDropEffects.Copy);
        }
        private void pbInitial13_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial13.DoDragDrop(pbInitial13.Image, DragDropEffects.Copy);
        }
        private void pbInitial14_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial14.DoDragDrop(pbInitial14.Image, DragDropEffects.Copy);
        }
        private void pbInitial15_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial15.DoDragDrop(pbInitial15.Image, DragDropEffects.Copy);
        }
        private void pbInitial16_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                pbInitial16.DoDragDrop(pbInitial16.Image, DragDropEffects.Copy);
        }

        private void pb1_DragDrop(object sender, DragEventArgs e)
        {
            pb1.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb1.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb2_DragDrop(object sender, DragEventArgs e)
        {
            pb2.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb2.Tag = checkTag();

            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb3_DragDrop(object sender, DragEventArgs e)
        {
            pb3.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb3.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb4_DragDrop(object sender, DragEventArgs e)
        {
            pb4.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb4.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb5_DragDrop(object sender, DragEventArgs e)
        {
            pb5.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb5.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb6_DragDrop(object sender, DragEventArgs e)
        {
            pb6.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb6.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb7_DragDrop(object sender, DragEventArgs e)
        {
            pb7.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb7.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb8_DragDrop(object sender, DragEventArgs e)
        {
            pb8.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb8.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb9_DragDrop(object sender, DragEventArgs e)
        {
            pb9.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb9.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb10_DragDrop(object sender, DragEventArgs e)
        {
            pb10.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb10.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb11_DragDrop(object sender, DragEventArgs e)
        {
            pb11.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb11.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb12_DragDrop(object sender, DragEventArgs e)
        {
            pb12.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb12.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb13_DragDrop(object sender, DragEventArgs e)
        {
            pb13.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb13.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb14_DragDrop(object sender, DragEventArgs e)
        {
            pb14.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb14.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb15_DragDrop(object sender, DragEventArgs e)
        {
            pb15.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb15.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb16_DragDrop(object sender, DragEventArgs e)
        {
            pb16.Image = (Bitmap)e.Data.GetData(DataFormats.Bitmap, true);
            pb16.Tag = checkTag();
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }

        private void pb1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin()) {
                show_Win_MessageBox();
            }
        }
        private void pb2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb7_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb8_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb9_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb10_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb12_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb13_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb14_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb15_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        private void pb16_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
            if (checkWin())
            {
                show_Win_MessageBox();
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////
        
        private void pbInitial01_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial01.ImageLocation;

        }
        private void pbInitial02_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial02.ImageLocation;

        }
        private void pbInitial03_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial03.ImageLocation;
        }
        private void pbInitial04_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial04.ImageLocation;
        }
        private void pbInitial05_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial05.ImageLocation;
        }
        private void pbInitial06_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial06.ImageLocation;
        }
        private void pbInitial07_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial07.ImageLocation;
        }
        private void pbInitial08_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial08.ImageLocation;
        }
        private void pbInitial09_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial09.ImageLocation;
        }
        private void pbInitial10_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial10.ImageLocation;
        }
        private void pbInitial11_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial11.ImageLocation;
        }
        private void pbInitial12_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial12.ImageLocation;
        }
        private void pbInitial13_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial13.ImageLocation;
        }
        private void pbInitial14_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial14.ImageLocation;
        }
        private void pbInitial15_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial15.ImageLocation;
        }
        private void pbInitial16_MouseEnter(object sender, EventArgs e)
        {
            current_Tag = pbInitial16.ImageLocation;
        }

        private void btnShowCompletePicture_Click(object sender, EventArgs e)
        {
            if (gameIsStarted)
            {
                if (hints == 0)
                {
                    //message: You Have Used three hints
                    MessageBox.Show("No more Hints Available!");
                    return;
                }
                hints--;
                this.btnShowCompletePicture.Text = "Show Picture Hints left: " + hints;
                //Message with PictureBox containing complete approperiate picture

                hint.ShowDialog();
            }
            else
                MessageBox.Show("Start the game first...");
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            hint.Dispose();
            pictureHint obj = new pictureHint();
            hint = obj;
            this.stop_Timer();
            this.reset_Timer();
            //Warning: the Current progress will be lost. /Continue button/cancel Button
            if (gameIsStarted)
                if (DialogResult.No == MessageBox.Show("Current Progress will be lost\n Do you want to continue?", "Warning", MessageBoxButtons.YesNo))
                    return;
            //DialogueBox with pictureBoxes of Game Pictures/Cancel Button
            this.clear_Game_Screen();
            this.start_Game();
            if (gameIsStarted)
            {
                this.reset_Game();
                hints = 3;
                this.btnShowCompletePicture.Text = "Show Picture Hints left: " + hints;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerIsActive)
            {
                timeCSEC--;
                if (timeCSEC < 0)
                {
                    current_Completion_Time++;
                    timeCSEC = 100;
                    timeSEC--;
                    if (timeSEC < 0)
                    {
                        timeSEC = 60;
                        timeMIN--;
                        
                        if (timeMIN < 0)
                        {
                            this.stop_Timer();
                            this.clear_Game_Screen();
                            hint.Dispose();
                            pictureHint obj = new pictureHint();
                            hint = obj;
                            if (DialogResult.No == MessageBox.Show("You are out of time.\n Wanna try again?", "Better Luck Next Time", MessageBoxButtons.YesNo)) return;
                            this.start_Game();
                            return;
                        }
                    }
                }
            }
            this.timeMin.Text = timeMIN + ":";
            this.timeSec.Text = timeSEC + ":";
            this.timeCSec.Text = timeCSEC + "";
        }

        private void btnWinings_Click(object sender, EventArgs e)
        {
            FrmTrophies = new frmTrophies();
            FrmTrophies.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Warning: Save the game before exiting yes/no
            if (DialogResult.No == MessageBox.Show("You will loose current Progress\n" +
                 "Do you want to exit?", "Warning", MessageBoxButtons.YesNo)) return;
            Application.Exit();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.stop_Timer();
            MessageBox.Show("Don't cheat!\nResume Game...", "Paused", MessageBoxButtons.OK);
            this.start_Timer();
        }

        public void saveTrophies_to_Database()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            Trophy NewTrophy = new Trophy()
            {
                CompletionTime = this.current_Completion_Time,
                DateTime = System.DateTime.Now
            };
            context.Trophies.InsertOnSubmit(NewTrophy);
            context.SubmitChanges();
        }
    }
}
