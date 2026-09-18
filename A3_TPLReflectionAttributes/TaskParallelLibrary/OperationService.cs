using System;
using System.Collections.Generic;
using System.Text;

namespace A3_TPLReflectionAttributes.TaskParallelLibrary
{
    public class OperationService
    {
        public void PerformOperation(int operationNumber)
        {
            // Simulate 100 ms of work.
            Thread.Sleep(100);
        }
    }
}
