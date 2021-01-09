using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObservableColletionSyncedTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        Random random = new Random();
        ObservableCollection<string> targetItems => (targets.ItemsSource as ObservableCollection<string>);
        ObservableCollection<int> sourcesItems => (sources.ItemsSource as ObservableCollection<int>);
        private int CreateSourceValue() => random.Next(0, 99);
        private int GetRandomIndex<T>(Collection<T> collection) => random.Next(0, collection.Count);

        private void AddSourceButton_Click(object sender, RoutedEventArgs e) =>
            sourcesItems.Add(CreateSourceValue());
        private void AddTargetButton_Click(object sender, RoutedEventArgs e) =>
            targetItems.Add($"A:{CreateSourceValue()}");

        private void RemoveSourceButton_Click(object sender, RoutedEventArgs e) =>
            sourcesItems.RemoveAt(GetRandomIndex(sourcesItems));
        private void RemoveTargetButton_Click(object sender, RoutedEventArgs e) =>
            targetItems.RemoveAt(GetRandomIndex(targetItems));
        private void ReplaceSourceButton_Click(object sender, RoutedEventArgs e) =>
            sourcesItems[GetRandomIndex(sourcesItems)] = CreateSourceValue();
        private void ReplaceTargetButton_Click(object sender, RoutedEventArgs e) =>
            targetItems[GetRandomIndex(targetItems)] = $"R:{CreateSourceValue()}";

        private void Move<T>(ObservableCollection<T> collection)
        {
            int indexOld = GetRandomIndex(collection);
            int indexNew = GetRandomIndex(collection);
            collection.Move(indexOld, indexNew);
        }
        private void MoveSourceButton_Click(object sender, RoutedEventArgs e) => Move(sourcesItems);
        private void MoveTargetButton_Click(object sender, RoutedEventArgs e) => Move(targetItems);

        private void ClearSourceButton_Click(object sender, RoutedEventArgs e) => sourcesItems.Clear();
        private void ClearTargetButton_Click(object sender, RoutedEventArgs e) => targetItems.Clear();
    }
}
