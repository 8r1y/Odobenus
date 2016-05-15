using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PxLookUp.Pages
{
    public class IntroPage : ContentPage
    {
        public IntroPage(TodoItemDatabase db)
        {
                Picker pagePicker = new Picker
                {
                    Title = "Page",
                    HorizontalOptions = LayoutOptions.Center
                };

                Picker optionPicker = new Picker
                {
                    Title = "Option",
                    HorizontalOptions = LayoutOptions.Center
                };

                optionPicker.IsEnabled = false;

                Picker filterPicker = new Picker
                {
                    Title = "Filter",
                    HorizontalOptions = LayoutOptions.Center
                };

                filterPicker.IsEnabled = false;

                pagePicker.Items.Add("Course");
                pagePicker.Items.Add("Menu");

                pagePicker.SelectedIndexChanged += (sender, args) =>
                {
                    optionPicker.IsEnabled = true;

                    if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Course"))
                    {
                        optionPicker.Items.Clear();
                        optionPicker.Items.Add("By Room");
                        optionPicker.Items.Add("By Group");
                        optionPicker.Items.Add("By Teacher");
                    }
                    else if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Menu"))
                    {
                        optionPicker.Items.Clear();
                        optionPicker.Items.Add("Lekker");
                    };
                };

                optionPicker.SelectedIndexChanged += (sender, args) =>
                {
                    filterPicker.IsEnabled = true;

                    var tv = optionPicker.Items.ElementAt(optionPicker.SelectedIndex);

                    var x = "";

                    switch (tv)
                    {
                        case "By Room":
                            x = "lokaal";
                            break;
                        case "By Group":
                            x = "klas";
                            break;
                        case "By Teacher":
                            x = "docent";
                            break;
                    }

                    filterPicker.Items.Clear();

                    foreach (var v in db.GetByColumn(x))
                    {
                        switch (optionPicker.Items.ElementAt(optionPicker.SelectedIndex))
                        {
                            case "By Room":
                                filterPicker.Items.Add(v.lokaal);
                                break;
                            case "By Group":
                                filterPicker.Items.Add(v.klas);
                                break;
                            case "By Teacher":
                                filterPicker.Items.Add(v.docent);
                                break;
                        }

                    }
                };

                filterPicker.SelectedIndexChanged += (sender, args) =>
                {
                    if(filterPicker.SelectedIndex != -1)
                    {
                        Navigation.PushAsync(new RoomPage(optionPicker.Items.ElementAt(optionPicker.SelectedIndex), db, filterPicker.Items.ElementAt(filterPicker.SelectedIndex)));
                    }                 
                };

                StackLayout l = new StackLayout();
                l.Children.Add(pagePicker);
                l.Children.Add(optionPicker);
                l.Children.Add(filterPicker);

                

                this.Content = l;
            }
        }

    }
