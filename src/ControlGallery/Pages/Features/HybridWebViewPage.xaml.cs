﻿using ControlGallery.Pages.Features;

namespace ControlGallery.Pages;

public partial class HybridWebViewPage : ContentPage
{
    private readonly TodoDataStore _todoDataStore;

    public HybridWebViewPage()
    {
        InitializeComponent();

        _todoDataStore = new TodoDataStore();
        _todoDataStore.TaskDataChanged += OnTodoDataChanged;

        myHybridWebView.JSInvokeTarget = new TodoJSInvokeTarget(this, _todoDataStore);

        BindingContext = this;
    }

    public string TodoAppTitle => $"Todo items: {_todoDataStore.GetData().Count}";

    private void OnTodoDataChanged(object sender, EventArgs e)
    {
        OnPropertyChanged(nameof(TodoAppTitle));
    }

    private async void SendUpdatedTasksToJS(IList<TodoTask> tasks)
    {
        _ = await MainThread.InvokeOnMainThreadAsync(async () =>
            await myHybridWebView.InvokeJsMethodAsync("globalSetData", tasks));
    }

    private sealed class TodoJSInvokeTarget
    {
        private HybridWebViewPage _mainPage;
        private readonly TodoDataStore _todoDataStore;

        public TodoJSInvokeTarget(HybridWebViewPage mainPage, TodoDataStore todoDataStore)
        {
            _mainPage = mainPage;
            _todoDataStore = todoDataStore;
        }

        public void StartTaskLoading()
        {
            _mainPage.SendUpdatedTasksToJS(_todoDataStore.GetData());
        }

        public void AddTask(TodoTask newTask)
        {
            _todoDataStore.AddTask(newTask);
        }

        public void EditTask(string id, string newName)
        {
            _todoDataStore.EditTask(id, newName);
        }

        public void DeleteTask(string id)
        {
            _todoDataStore.DeleteTask(id);
        }

        public void ToggleCompletedTask(string id)
        {
            _todoDataStore.ToggleCompletedTask(id);
        }
    }
}