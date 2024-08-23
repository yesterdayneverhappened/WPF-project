using NUnit.Framework;
using Курсач.ViewModels;
using Курсач.Models;
using Курсач.Views;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;

namespace Курсач.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private MainViewModel _viewModel;
        private MainWindow _mainWindow;

        [SetUp]
        public void Setup()
        {
            _viewModel = new MainViewModel();
            _mainWindow = new MainWindow { DataContext = _viewModel };
        }

        [Test]
        public void AddItem_ShouldAddItemToListAndUpdateUI()
        {
            // Arrange
            var item = new TodoItem { Title = "Test Item" };

            // Act
            _viewModel.AddItem(item);

            // Assert
            Assert.AreEqual(1, _viewModel.TodoItems.Count);
            Assert.AreEqual(1, _mainWindow.TodoListBox.Items.Count);
            Assert.Contains(item, _viewModel.TodoItems);
            Assert.Contains(item, _mainWindow.TodoListBox.Items);
        }

        [Test]
        public async Task SaveItems_ShouldPersistDataToStorage()
        {
            // Arrange
            var items = new List<TodoItem>
            {
                new TodoItem { Title = "Task 1" },
                new TodoItem { Title = "Task 2" },
                new TodoItem { Title = "Task 3" }
            };
            _viewModel.TodoItems = items;

            // Act
            await _viewModel.SaveItemsAsync();

            // Assert
            var storedItems = await _viewModel.LoadItemsAsync();
            CollectionAssert.AreEqual(items, storedItems);
        }

        [Test]
        public void MarkItemAsComplete_ShouldUpdateItemStatusAndUI()
        {
            // Arrange
            var item = new TodoItem { Title = "Test Item" };
            _viewModel.AddItem(item);

            // Act
            _viewModel.MarkItemAsComplete(item);

            // Assert
            Assert.IsTrue(item.IsComplete);
            Assert.IsTrue(_mainWindow.TodoListBox.SelectedItem is TodoItem && ((TodoItem)_mainWindow.TodoListBox.SelectedItem).IsComplete);
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemFromListAndUpdateUI()
        {
            // Arrange
            var item = new TodoItem { Title = "Test Item" };
            _viewModel.AddItem(item);

            // Act
            _viewModel.RemoveItem(item);

            // Assert
            Assert.AreEqual(0, _viewModel.TodoItems.Count);
            Assert.AreEqual(0, _mainWindow.TodoListBox.Items.Count);
            Assert.IsFalse(_viewModel.TodoItems.Contains(item));
            Assert.IsFalse(_mainWindow.TodoListBox.Items.Contains(item));
        }
    }

    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        public void AddManyItems_ShouldAddItemsQuickly()
        {
            // Arrange
            var viewModel = new MainViewModel();
            var items = new List<TodoItem>();
            for (int i = 0; i < 10000; i++)
            {
                items.Add(new TodoItem { Title = $"Item {i}" });
            }

            // Act
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in items)
            {
                viewModel.AddItem(item);
            }
            stopwatch.Stop();

            // Assert
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(1000), "Adding 10,000 items should take less than 1 second.");
        }
    }
}