using System;
using System.Collections.Generic;
using System.Text;

namespace A3_ExceptionsDisposalAsync.Disposal
{
    public class TempFileManager : IDisposable
    {
        public string FilePath { get; }

        private bool disposed;

        // Constructor
        public TempFileManager()
        {
            FilePath =
                Path.Combine(
                    Path.GetTempPath(),
                    $"temp_{Guid.NewGuid()}.txt"
                );

            File.WriteAllText( FilePath, "Temporary file content.");

            Console.WriteLine( $"Temp file created: {FilePath}");
        }

        // Dispose method
        public void Dispose()
        {
            Dispose(true);

            // The object has already performed
            // deterministic cleanup, so the finalizer
            // does not need to run.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Managed resource cleanup
            }

            // Delete temporary file
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);

                Console.WriteLine("Temp file deleted.");
            }

            disposed = true;
        }

        // Finalizer
        ~TempFileManager()
        {
            Dispose(false);
        }
    }
}
