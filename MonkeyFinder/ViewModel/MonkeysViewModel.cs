﻿using CommunityToolkit.Mvvm.Input;
using Services;
using System.Linq.Expressions;

namespace ViewModel;
public partial class MonkeysViewModel : BaseViewModel
{
        MonkeyService monkeyService;
        public ObservableCollection<Monkey> Monkeys { get; set; } = new();
        public MonkeysViewModel(MonkeyService monkeyService)
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
        }
    [RelayCommand]
    async Task GetMonkeyAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

            if(Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get monkeys: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }
}