namespace singleton {
    public class FileSystem {
        private static readonly FileSystem instance = new FileSystem();

        private FileSystem() {
        }

        public static FileSystem Instance {
            get { return instance; }
        }
    }

    public class WindowsFileSystem : FileSystem {
        public override string ReadFile(string path) {
            return File.ReadAllText(path);
        }

        public override void WriteFile(
            string path,
            string contents) {
            File.WriteAllText(path, contents);
        }
    }
}
