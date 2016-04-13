﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace CaptIt
{
    public class HotKeyManager
    {
        public static CaptureLib ScreenCapture = new CaptureLib();
        public static List<SShot> Hotkeys = new List<SShot>();

        public HotKeyManager()
        {
            FullScreenShot FSS = new FullScreenShot();
            Hotkeys.Add(FSS);

            DragScreenShot DSS = new DragScreenShot();
            Hotkeys.Add(DSS);

            HotKeyScreenShot HKSS0 = new HotKeyScreenShot(0);
            Hotkeys.Add(HKSS0);

            HotKeyScreenShot HKSS1 = new HotKeyScreenShot(1, Keys.Alt | Keys.D2, Keys.D2 | Keys.Alt | Keys.Control);
            Hotkeys.Add(HKSS1);

            HotKeyScreenShot HKSS2 = new HotKeyScreenShot(2, Keys.Alt | Keys.D3, Keys.D3 | Keys.Alt | Keys.Control);
            Hotkeys.Add(HKSS2);

            HotKeyScreenShot HKSS3 = new HotKeyScreenShot(3, Keys.Alt | Keys.D4, Keys.D4 | Keys.Alt | Keys.Control);
            Hotkeys.Add(HKSS3);

            WindowScreenShot WSS = new WindowScreenShot();
            Hotkeys.Add(WSS);

            BurstScreenShot BSS = new BurstScreenShot(4);
            Hotkeys.Add(BSS);

            foreach (SShot s in Hotkeys)
            {
                if (s is HotKeyScreenShot)
                    SaveHotKeySet(s as HotKeyScreenShot);
                else if (s is WindowScreenShot)
                    SaveHandleKeySet((WindowScreenShot)s);
                else
                    SaveKeySet(s);
            }
        }

        public bool isHotKeyed(Keys k)
        {
            foreach(SShot s in Hotkeys)
            {
                if (s.Key == k) return true;
            }
            return false;
        }

        public SShot CapturHotkeyed(Keys k)
        {
            foreach (SShot s in Hotkeys)
            {
                if (s.Key == k) return s;
            }

            throw new Exception("HotKeyManager CaptureHotKeyed Not Exist in HotKeys List");
        }
        
        public bool isHotKeyHotkeyed(Keys k)
        {
            foreach (SShot s in Hotkeys)
            {
                if (s.isHotKeyScreenShot) if (((HotKeyScreenShot)s).SetKey == k) return true;
            }
            return false;
        }
        
        public HotKeyScreenShot CaptureSetKeyed(Keys k)
        {
            foreach (SShot s in Hotkeys)
            {
                if (s.isHotKeyScreenShot) if (((HotKeyScreenShot)s).SetKey == k) return s as HotKeyScreenShot;
            }

            throw new Exception("HotKeyManager CaptureSetKeyed Not Exist in HotKeys List");
        }

        public bool isHandleHotKeyed(Keys k)
        {
            foreach(SShot s in Hotkeys)
            {
                if (s is WindowScreenShot) if (((WindowScreenShot)s).SetKey == k) return true;
            }
            return false;
        }

        public WindowScreenShot CaptureHandleHotKeyed(Keys k)
        {
            foreach (SShot s in Hotkeys)
            {
                if (s is WindowScreenShot) if (((WindowScreenShot)s).SetKey == k) return (WindowScreenShot)s;
            }
            throw new Exception("HotKeyManager CaptureHandleHotKeyed Not Exist in HotKeys List");
        }

        public static void SaveKeySet(SShot s)
        {
            MainForm.Setting.iniSave.WriteSetting("HotKey", s.shotType, s.Key.ToString());
        }

        public static void SaveHotKeySet(HotKeyScreenShot s)
        {
            MainForm.Setting.iniSave.WriteSetting("HotKey", s.Code.ToString(), s.Key.ToString() + "|" + s.SetKey.ToString());
        }

        public static void SaveHandleKeySet(WindowScreenShot s)
        {
            MainForm.Setting.iniSave.WriteSetting("HotKey", "handle", s.Key.ToString() + "|" + s.SetKey.ToString());
        }

        public static Keys GetKeySet(SShot s)
        {
            return (Keys)Enum.Parse(typeof(Keys), MainForm.Setting.iniSave.GetSetting("HotKey", s.shotType));
        }

        public static Keys[] GetHotKeySet(HotKeyScreenShot s)
        {
            string[] str = MainForm.Setting.iniSave.GetSetting("HotKey", s.Code.ToString()).Split('|');
            Keys k = (Keys)Enum.Parse(typeof(Keys), str[0]);
            Keys setK = (Keys)Enum.Parse(typeof(Keys), str[1]);
            return new Keys[] { k, setK };
        }

        public static Keys[] GetHandleKeySet(WindowScreenShot s)
        {
            string[] str = MainForm.Setting.iniSave.GetSetting("HotKey", "handle").Split('|');
            Keys k = (Keys)Enum.Parse(typeof(Keys), str[0]);
            Keys setK = (Keys)Enum.Parse(typeof(Keys), str[1]);
            return new Keys[] { k, setK };
        }

        public static void SaveRect(HotKeyScreenShot s)
        {
            string str = s.Rect.X + "|" + s.Rect.Y + "|" + s.Rect.Width + "|" + s.Rect.Height;
            MainForm.Setting.iniSave.WriteSetting("HotKeyRect", s.Code.ToString(), str);
        }

        public static Rectangle GetRect(HotKeyScreenShot s)
        {
            string[] str = MainForm.Setting.iniSave.GetSetting("HotKeyRect", s.Code.ToString()).Split('|');
            return new Rectangle(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]), Convert.ToInt32(str[3]));
        }

        public static void ShowCheckCapturedForm(Image img, string path)
        {
            if (MainForm.Setting.isShowCheckCapturedForm)
            {
                bool autosave = false;
                if (MainForm.Setting.isSaveAutoAfterCaptureSShot)
                {
                    autosave = true;
                }
                SShotCaptured s = new SShotCaptured(img, autosave, path);
                s.Show();
            }
        }

        public static string SaveImage(Image img)
        {
            string path = string.Empty;
            try
            {
                path = MainForm.Setting.AutoSavePath + "\\" + MainForm.Setting.AutoSaveFileName + " " + MainForm.Setting.GETAutoSaveFileNumber();
                System.Drawing.Imaging.ImageFormat imgF;
                switch(MainForm.Setting.ImageSaveFormat)
                {
                    case ImageSaveFormat.PNG:
                        {
                            imgF = System.Drawing.Imaging.ImageFormat.Png;
                            path += ".png";
                            break;
                        }
                    case ImageSaveFormat.JPG:
                        {
                            imgF = System.Drawing.Imaging.ImageFormat.Jpeg;
                            path += ".jpg";
                            break;
                        }
                    case ImageSaveFormat.BMP:
                        {
                            imgF = System.Drawing.Imaging.ImageFormat.Bmp;
                            path += ".bmp";
                            break;
                        }
                }
                img.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, e.TargetSite.ToString());
            }
            ShowCheckCapturedForm(img, path);

            return path;
        }

        public static void ShowImageEditor(string path, Image img)
        {
            if (MainForm.Setting.isShowEditorAfterCaptureSShot)
            {
                System.Diagnostics.Process.Start("mspaint.exe", string.Format("\"{0}\"", path));
            }
            if(MainForm.Setting.isCopytoClipboard)
            {
                Clipboard.SetImage(img);
            }
        }
    }

    public abstract class SShot
    {
        public abstract string shotType { get; }
        public abstract void CaptureSShot();
        public abstract Keys Key { get; set; }
        public bool isHotKeyScreenShot = false;

        
    }

    public class FullScreenShot : SShot
    {
        public override string shotType { get { return "FullSShot"; } }

        private Keys key = Keys.F12;
        public override Keys Key { get { return key; }
            set { key = value; } }

        public FullScreenShot()
        {
            try
            {
                this.key = HotKeyManager.GetKeySet(this);
            }
            catch { }
        }

        ~FullScreenShot() { HotKeyManager.SaveKeySet(this); }

        public override void CaptureSShot()
        {
            Image capturedSS = HotKeyManager.ScreenCapture.CaptureScreen();

            string path = HotKeyManager.SaveImage(capturedSS);
            HotKeyManager.ShowImageEditor(path, capturedSS);

            if (capturedSS != null) capturedSS.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    public class DragScreenShot : SShot
    {
        public override string shotType { get { return "DragSShot"; } }
        private Keys key = Keys.F12 | Keys.Shift;
        public override Keys Key { get { return key; } set { key = value; } }
        bool isDragMode = false;

        public DragScreenShot()
        {
            try
            {
                this.key = HotKeyManager.GetKeySet(this);
            }
            catch { }
        }
        ~DragScreenShot()
        {
            HotKeyManager.SaveKeySet(this);
        }

        public override void CaptureSShot()
        {
            if (isDragMode) return;
            isDragMode = true;

            dragForm d = new dragForm();
            d.dragFinished += (rect, capturedSS) =>
            {
                string path = HotKeyManager.SaveImage(capturedSS);
                HotKeyManager.ShowImageEditor(path, capturedSS);

                isDragMode = false;

                if (capturedSS != null) capturedSS.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            };
            d.dragCanceled += () => { isDragMode = false; };
            d.ShowDialog();
        }
    }

    public class HotKeyScreenShot : SShot
    {
        public override string shotType { get { return "HotKeySShot"; } }
        
        public HotKeyScreenShot(int code)
        {
            this.isHotKeyScreenShot = true;
            try
            {
                Keys[] keys = HotKeyManager.GetHotKeySet(this);
                this.key = keys[0]; this.setKey = keys[1];
            }
            catch { }
            this.Rect = HotKeyManager.GetRect(this);
            this.Code = code;
        }

        public HotKeyScreenShot(int code, Keys key, Keys setKey)
        {
            this.isHotKeyScreenShot = true;
            try
            {
                Keys[] keys = HotKeyManager.GetHotKeySet(this);
                this.key = keys[0]; this.setKey = keys[1];
            }
            catch
            {
                this.key = key;
                this.setKey = setKey;
            }
            this.Rect = HotKeyManager.GetRect(this);
            this.Code = code;
        }

        ~HotKeyScreenShot()
        {
            HotKeyManager.SaveHotKeySet(this);
        }

        public int Code;

        private Keys key = Keys.D1 | Keys.Alt;
        public override Keys Key { get { return key; }
            set { key = value; } }
        public Rectangle Rect { get; set; }

        private Keys setKey = Keys.D1 | Keys.Alt | Keys.Control;
        public Keys SetKey { get { return setKey; } set { setKey = value; } }

        public override void CaptureSShot()
        {
            if (Rect == null)
            {
                MessageBox.Show("올바르지 않은 영역이 맵핑되어 있습니다!");
                return;
            }

            this.Rect = CaptureLib.InitializedSize(CaptureLib.fullScreensSize(), Rect);
            Image capturedSS = HotKeyManager.ScreenCapture.CaptureScreen(Rect);

            string path = HotKeyManager.SaveImage(capturedSS);
            HotKeyManager.ShowImageEditor(path, capturedSS);

            if (capturedSS != null) capturedSS.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        bool isDragMode = false;

        public void SetRect()
        {
            if (isDragMode) return;
            isDragMode = true;

            dragForm d = new dragForm();
            d.dragFinished += (rect, img) =>
            {
                this.Rect = rect;
                isDragMode = false;
                HotKeyManager.SaveRect(this);
                img.Dispose();
            };
            d.dragCanceled += () => { isDragMode = false; };
            d.ShowDialog();
        }
    }

    public class WindowScreenShot : SShot
    {
        public override string shotType { get { return "WindowScreenShot"; } }
        private Keys key = Keys.F11;
        public override Keys Key
        {
            get { return key; }
            set { key = value; }
        }
        private Keys setKey = Keys.F11 | Keys.Shift;
        public Keys SetKey { get { return setKey; } set { setKey = value; } }

        bool isDragMode = false;

        public IntPtr windowHandle;

        public WindowScreenShot()
        {
            try
            {
                Keys[] k = HotKeyManager.GetHandleKeySet(this);
                this.key = k[0];
                this.setKey = k[1];
            }
            catch { }
        }

        public override void CaptureSShot()
        {
            try
            {
                Image capturedSS = HotKeyManager.ScreenCapture.CaptureWindow(windowHandle);
                string path = HotKeyManager.SaveImage(capturedSS);
                HotKeyManager.ShowImageEditor(path, capturedSS);

                if (capturedSS != null) capturedSS.Dispose();
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public void SetWindowHandle()
        {
            if (isDragMode) return;
            isDragMode = true;
            GetWindowProcess form = new GetWindowProcess();
            form.captFinished += (h) => { windowHandle = h; isDragMode = false; };
            form.captCanceled += () => isDragMode = false;
            form.ShowDialog();
        }
    }

    public class BurstScreenShot : HotKeyScreenShot
    {
        public override string shotType { get { return "BurstScreenShot"; } }
        private Keys key = Keys.F8;
        public override Keys Key
        {
            get { return key; }
            set { key = value; }
        }
        

        public int Gap = 1000;
        private int currentGap = 0;
        private bool isCapturing = false;
        private Timer t = new Timer() { Enabled = false };
        private bool isPressedWhilePressTurnedOn = false;

        public BurstScreenShot(int code) : base(code)
        {
            t.Tick += T_Tick;
            this.SetKey = Keys.Shift | Keys.F8;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if(isCapturing)
            {
                currentGap += t.Interval;
            }

            if(currentGap >= Gap)
            {
                if(isPressedWhilePressTurnedOn)
                {
                    try
                    {
                        if (Rect == null)
                        {
                            MessageBox.Show("올바르지 않은 영역이 맵핑되어 있습니다!");
                            return;
                        }

                        this.Rect = CaptureLib.InitializedSize(CaptureLib.fullScreensSize(), Rect);
                        Image capturedSS = HotKeyManager.ScreenCapture.CaptureScreen(Rect);
                        string path = HotKeyManager.SaveImage(capturedSS);
                        HotKeyManager.ShowImageEditor(path, capturedSS);

                        if (capturedSS != null) capturedSS.Dispose();
                    }
                    finally
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }

                    isPressedWhilePressTurnedOn = false;
                    currentGap = 0;
                }
                else
                {
                    t.Enabled = false;
                }
            }
        }

        public override void CaptureSShot()
        {
            if (!isCapturing)
            {
                isCapturing = true;
                return;
            }

            t.Enabled = true;
            isPressedWhilePressTurnedOn = true;
        }
    }
}