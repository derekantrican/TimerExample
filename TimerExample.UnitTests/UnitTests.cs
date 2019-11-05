using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimerExample.ViewModels;

namespace TimerExample.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(0)]
        [DataRow(20)]
        public void TimerTest(int secondsToWait)
        {
            TimerViewModel viewModel = new TimerViewModel();
            Thread.Sleep(1000 * secondsToWait);

            Assert.AreEqual(secondsToWait, viewModel.TimerValue, 1);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(-1, 0)]
        [DataRow(0, 0)]
        [DataRow(500, 500)]
        [DataRow(-500, 0)]
        public void OverrideTimerValueTest(int newTimerValue, int expectedResultTimerValue)
        {
            TimerViewModel viewModel = new TimerViewModel(false);
            viewModel.TimerOverrideValue = newTimerValue;
            viewModel.SetTimerCommand.Execute(null);
            Assert.AreEqual(expectedResultTimerValue, viewModel.TimerValue);
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(5, 5)]
        [DataRow(0, 0)]
        [DataRow(500, 500)]
        public void IncrementValueTest(int timesToIncrement, int expectedResult)
        {
            TimerViewModel viewModel = new TimerViewModel(false);
            for (int i = 0; i < timesToIncrement; i++)
                viewModel.IncrementAmountCommand.Execute(null);

            Assert.AreEqual(expectedResult, viewModel.IncrementalValue);
        }
    }
}
