using PxLookUp.Model;
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
                    if(optionPicker.IsEnabled == false)
                    {
                        optionPicker.IsEnabled = true;
                    }

                    if(pagePicker.SelectedIndex != -1)
                    {
                        if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Course"))
                        {
                            optionPicker.Items.Clear();
                            optionPicker.Items.Add("By Room");
                            optionPicker.Items.Add("By Group");
                            optionPicker.Items.Add("By Teacher");
                            optionPicker.SelectedIndex = 1;
                        }
                        else if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Menu"))
                        {
                            optionPicker.Items.Clear();
                            optionPicker.Items.Add("By Location");
                            optionPicker.SelectedIndex = 1;
                        };
                    }
                };

                optionPicker.SelectedIndexChanged += (sender, args) =>
                {
                    if(filterPicker.IsEnabled == false)
                    {
                        filterPicker.IsEnabled = true;
                    }

                    if(optionPicker.SelectedIndex != -1)
                    {
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
                            case "By Location":
                                x = "Locatie";
                                break;
                        }

                        filterPicker.Items.Clear();

                        List<TodoItem> items = new List<TodoItem>();

                        if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Course"))
                        {
                            items = db.GetCourseByColumn(x).ToList<TodoItem>();
                        }
                        else if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Menu"))
                        {
                            items = db.GetMenuByColumn(x).ToList<TodoItem>();
                        }

                        foreach (var v in items)
                        {
                            switch (optionPicker.Items.ElementAt(optionPicker.SelectedIndex))
                            {
                                case "By Room":
                                    Course c1 = (Course)v;
                                    filterPicker.Items.Add(c1.lokaal);
                                    break;
                                case "By Group":
                                    Course c2 = (Course)v;
                                    filterPicker.Items.Add(c2.klas);
                                    break;
                                case "By Teacher":
                                    Course c3 = (Course)v;
                                    filterPicker.Items.Add(c3.docent);
                                    break;
                                case "By Location":
                                    Menu menu = (Menu)v;
                                    filterPicker.Items.Add(menu.Locatie);
                                    break;

                            }
                        }
                    }
                };

                filterPicker.SelectedIndexChanged += (sender, args) =>
                {
                    if(filterPicker.SelectedIndex != -1)
                    {
                        if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Course"))
                        {
                            Navigation.PushAsync(new RoomPage(optionPicker.Items.ElementAt(optionPicker.SelectedIndex), db, filterPicker.Items.ElementAt(filterPicker.SelectedIndex)));
                        }
                        else if (pagePicker.Items.ElementAt(pagePicker.SelectedIndex).Equals("Menu"))
                        {
                            Navigation.PushAsync(new CateringPage(db, filterPicker.Items.ElementAt(filterPicker.SelectedIndex)));
                        }
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
