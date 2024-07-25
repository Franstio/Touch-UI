using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTCP1.Model;

namespace TestTCP1.Lib
{
    public class FileLib
    {
        public string _filePath { get; private set; } = string.Empty;
        public  string _savePath { get; private set; } = string.Empty;
        public string _ngSavePath { get; private set; } = string.Empty;
        public string _logPath { get; private set; } = string.Empty;
        public string _markSaveDir { get; private set; } = string.Empty;
        public string _snResultPath { get;private set; } = string.Empty;
        public int _snResultDelay { get; private set; } = 0;
        private string basename_folder = "SD1_";
        public int FolderCode { get; set; } = 1;
        public FileLib()
        {
            string settingPath = Properties.Settings.Default["ImageDirName"]?.ToString() ?? "img";
            string savePath = Properties.Settings.Default["SaveImageDirName"]?.ToString() ?? "img";
            string ngSavePath = Properties.Settings.Default["NgImageDirName"]?.ToString() ?? "ng";
            string logPath = Properties.Settings.Default["LogPath"]?.ToString() ?? "log";
            string markSaveDir = Properties.Settings.Default["MarkSaveDir"]?.ToString() ?? "markImg";
            string snResultPath = Properties.Settings.Default["SNResultPath"]?.ToString() ?? "result";
            _filePath = settingPath.Contains(":\\") || settingPath.Contains(":/") ? settingPath :  Path.Combine( AppDomain.CurrentDomain.BaseDirectory,
                 settingPath);
            _savePath = savePath.Contains(":\\") || savePath.Contains(":/") ? savePath  : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                 savePath);
            _ngSavePath = ngSavePath.Contains(":\\") || ngSavePath.Contains(":/") ? ngSavePath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                ngSavePath);
            _logPath = logPath.Contains(":\\") || logPath.Contains(":/") ? logPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                logPath);

            _markSaveDir = markSaveDir.Contains(":\\") || markSaveDir.Contains(":/") ? markSaveDir : Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                markSaveDir);
            _snResultPath = snResultPath.Contains(":\\") || snResultPath.Contains(":/") ? snResultPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, snResultPath);
            _snResultDelay = int.Parse(Properties.Settings.Default["SNResultDelay"].ToString()??"0");
            try
            {
                if (!Directory.Exists(_filePath))
                    Directory.CreateDirectory(_filePath);
                if (!Directory.Exists(_savePath))
                    Directory.CreateDirectory(_savePath);
                if (!Directory.Exists(_ngSavePath))
                    Directory.CreateDirectory(_ngSavePath);
                if (!Directory.Exists(_logPath))
                    Directory.CreateDirectory(_logPath);
                if (!Directory.Exists(_markSaveDir))
                    Directory.CreateDirectory(_markSaveDir);
                if (!Directory.Exists(_snResultPath))
                    Directory.CreateDirectory(_snResultPath);
                Console.WriteLine(_filePath);
                Console.WriteLine(_savePath);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Image? ReadImage(string imageName,bool local = false, string? manualPath = null)
        {
            Image img;
            try
            {
                img = Image.FromFile(Path.Combine(manualPath is null ? (local ? _savePath : _ngSavePath ): manualPath, imageName));
                return img;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message +$" {imageName}", "Image Load Error");
                return null;
            }
        }
        public void SaveImage(string imagePath,string name,bool ng=false, string? manualPath = null)
        {
            if (!File.Exists(imagePath))
            {
                MessageBox.Show($"Path {imagePath} Not Found", "File Error");
                return;
            }
            string savepath = Path.Combine(manualPath is null ? (ng ? _ngSavePath : _savePath) : manualPath,name);
            try
            {
                if (File.Exists(savepath))
                    File.Delete(savepath);
                var img = Image.FromFile(imagePath);
                img.Save(savepath);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message},PATH:{imagePath},TO:{savepath})");
            }
        }
        public string[] GetFolders(string search = "")
        {
            string fullbasename_folder = basename_folder + FolderCode.ToString("D3");
            string fullpath = Path.Combine(_filePath, fullbasename_folder);
            if (!Directory.Exists(fullpath))
            {
                MessageBox.Show($"Directory {fullpath} is not exists", "Directory Not Found");
                //throw new Exception($"Directory {fullpath} is not exists");
                return new string[0];
            }
            var dirs = Directory.GetDirectories(fullpath);
            if (dirs is null)
            {
                MessageBox.Show($"Path {fullpath} Not Found", "File Error");
                return new string[0];
            }
            return search== "" ? dirs.OrderByDescending(x=>x).ToArray() : dirs.Where(x=>x.Contains(search)).OrderByDescending(x=>x).ToArray();
        }
        public async Task<string[]> GetFiles(string path,string search="")
        {
            int trycount = 0;
            var files = Directory.GetFiles(path);
            if (files is null)
            {
                MessageBox.Show($"Path {path} Not Found", "File Error");
                return new string[0];
            }
            while (files.Length < 1 && trycount <= 10)
            {
                await Task.Delay(100);
                files = Directory.GetFiles(path);
                Debug.WriteLineIf(files.Length < 1, $"Retry fetching image on: {path}, count: {trycount+1}");
                trycount += 1;
            }
            return search == "" ? files.OrderByDescending(x=>x).ToArray() : files.Where(x => x.Contains(search)).OrderByDescending(x => x).ToArray();
        }
        public async Task<string> GenerateLog(List<RecordInspectionModel> Records, string ScanCode)
        {
            if (Records.Count < 1)
                return string.Empty;
            string Log =
               /// "Content:\n" +
               /// $"Model: {Records.First().Model}\n"+
                $"SN : {ScanCode}\n"+
                "Result : "+(Records.Any(x=>x.Judgement=="NG") ? "FAIL" : "PASS" )+"\n\n";
            StringBuilder sb = new StringBuilder(Log);
            foreach (var record in Records) 
            {
                if (record.Judgement=="NG" || !string.IsNullOrEmpty(record.Reason) )
                    sb.AppendLine(
                        $"Position: {record.Pos}\n" +
                        $"Judgement: {record.Judgement}\n" +
                        $"Area Inspection: {record.AreaInspection}" + (record.Reason is null ?  string.Empty : (" # " + record.Reason)) + "\n"+
                        $"Image: {record.FileName}\n"
                    );
            }
            sb.AppendLine("End");
            string filename = $"{DateTime.Now.ToString("yyyyMMdd")}_{ScanCode}.txt";
            for (int i = 0; i <2; i++)
            {
                string _path = Path.Combine(_logPath,i.ToString(),filename);
                if (i == 0)
                    _path = Path.Combine(_logPath, filename);
                else
                {
                    _path = Path.Combine(_logPath, "result", filename);
                    if (!Directory.Exists(Path.Combine(_logPath, "result")))
                        Directory.CreateDirectory(Path.Combine(_logPath,"result"));
                }    
                if (File.Exists(_path))
                    File.Delete(_path);
                using (StreamWriter sw = new StreamWriter(_path))
                {
                    await sw.WriteAsync(sb);
                    await sw.FlushAsync();
                }
            }
            return filename;
        }
        public async Task<bool> ValidateLog(string ScanCode)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "result");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            await Task.Delay(1000);
            string[] files = Directory.GetFiles(path);
            bool result = (files.Length > 0 || files.Any(x => x.Contains(".txt")));
            return !result;
            if (result)
            {
//                string filename = $"{DateTime.Now.ToString("yyyyMMdd")}_{ScanCode}.txt";
 //               File.Delete(Path.Combine(_logPath,filename));
                return false;
            }
            return true;
        } 
        public async Task<Dictionary<string,string>?> ValidateLog()
        {
            await Task.Delay(TimeSpan.FromSeconds(_snResultDelay));
            string[] files = Directory.GetFiles(_snResultPath);
            if (files.Length == 0)
                return null;
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            for (int i=0;i<files.Length; i++)
            {
                using (StreamReader reader = new StreamReader(File.OpenRead(files[i])))
                    Dict.Add(files[i].Split(" ").Last().Replace(" ","").Trim(),reader.ReadToEnd());
                File.Delete(files[i]);
            }
            return Dict ;
        }
    }
}
