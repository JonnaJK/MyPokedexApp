﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PokedexGo.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    internal void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    // TOOD: NEW Eventuellt ta bort? 
    protected bool SetProperty<T>(ref T backingStore, T value,
       [CallerMemberName] string propertyName = "",
       Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }
}
