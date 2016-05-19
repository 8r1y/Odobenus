using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PxLookUp.Pages
{
    public class RoomPage : TabbedPage
    {
        public RoomPage(string title, TodoItemDatabase db, string value)
        {
            this.Title = title;

            List<Course> list = new List<Course>(); ;

            switch (title)
            {
                case "By Room":
                    list = db.GetCourseByRoom(value);
                    break;
                case "By Group":
                    list = db.GetCourseByGroup(value);
                    break;
                case "By Teacher":
                    list = db.GetCourseByTeacher(value);
                    break;
            }

            this.Children.Add(new DayPage(new ContentService().FilterByDay(list, "Monday"))
            {
                Title = "Monday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterByDay(list, "Tuesday"))
            {
                Title = "Tuesday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterByDay(list, "Wednesday"))
            {
                Title = "Wednesday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterByDay(list, "Thursday"))
            {
                Title = "Thursday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterByDay(list, "Friday"))
            {
                Title = "Friday"
            });
        }

        public class DayPage : ContentPage
        {
            public DayPage(List<Course> list)
            {
                this.SetBinding(ContentPage.TitleProperty, "Name");

                Label hourSLabel;
                Label hourELabel;
                Label roomLabel;
                Label groupLabel;
                Label lectureLabel;
                Label teacherLabel;

                ListView listView = new ListView
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    RowHeight = 150,

                    ItemsSource = list,

                    ItemTemplate = new DataTemplate(() =>
                    {
                        hourSLabel = new Label
                        {
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            HorizontalOptions = LayoutOptions.Center,
                            LineBreakMode = LineBreakMode.NoWrap
                        };
                        hourELabel = new Label
                        {
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            HorizontalOptions = LayoutOptions.Center,
                            LineBreakMode = LineBreakMode.NoWrap
                        };
                        roomLabel = new Label
                        {
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            HorizontalOptions = LayoutOptions.Center,
                            LineBreakMode = LineBreakMode.NoWrap
                        };
                        groupLabel = new Label
                        {
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalTextAlignment = TextAlignment.Center
                        };
                        lectureLabel = new Label
                        {
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalTextAlignment = TextAlignment.Center
                        };
                        teacherLabel = new Label
                        {
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalTextAlignment = TextAlignment.Center
                        };

                        hourSLabel.SetBinding(Label.TextProperty, "van_uur");
                        hourELabel.SetBinding(Label.TextProperty, "tot_uur");
                        roomLabel.SetBinding(Label.TextProperty, "lokaal");
                        groupLabel.SetBinding(Label.TextProperty, "klas");
                        lectureLabel.SetBinding(Label.TextProperty, "olod");
                        teacherLabel.SetBinding(Label.TextProperty, "docent");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,                     

                                Children =
                                {
                                    new StackLayout
                                    {
                                        Orientation = StackOrientation.Vertical,
                                        HorizontalOptions = LayoutOptions.StartAndExpand,
                                        MinimumWidthRequest = 50,

                                        Children =
                                        {
                                            roomLabel, hourSLabel, hourELabel
                                        }
                                    },

                                    new StackLayout
                                    {
                                        Orientation = StackOrientation.Vertical,
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        VerticalOptions = LayoutOptions.Center,

                                        Children =
                                        {
                                            groupLabel, lectureLabel, teacherLabel
                                        }
                                    }
                                }
                            }
                        };
                    })
                };
                this.Content = listView;
            }
        }
    }
}
