using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableColletionSyncedTest
{
class MainWindowViewModel
{
    public ObservableCollection<int> Sources { get; } = new ObservableCollection<int>(new[] { 10, 20, 30 });
    public ObservableCollection<string> Targets { get; }

    public MainWindowViewModel()
    {

        Targets = Sources
            .ToObservableCollctionSynced(
            x => $"C:{x}",
            x => int.Parse(x.Substring(2)));
    }
}
}
