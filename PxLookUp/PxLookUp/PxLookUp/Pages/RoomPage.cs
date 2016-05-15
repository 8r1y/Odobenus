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
                    list = db.GetCourseByRoom(value);
                    break;
                case "By Teacher":
                    list = db.GetCourseByRoom(value);
                    break;
            }

            this.Children.Add(new DayPage(list)
            {
                Title = "Monday"
            });
            this.Children.Add(new DayPage(list)
            {
                Title = "Tuesday"
            });
            this.Children.Add(new DayPage(list)
            {
                Title = "Wednesday"
            });
            this.Children.Add(new DayPage(list)
            {
                Title = "Thursday"
            });
            this.Children.Add(new DayPage(list)
            {
                Title = "Friday"
            });
        }

        public class DayPage : ContentPage
        {
            public DayPage(List<Course> list)
            {
                // This binding is necessary to label the tabs in
                // the TabbedPage.
                this.SetBinding(ContentPage.TitleProperty, "Name");
                // BoxView to show the color.

                ListView listView = new ListView
                {                
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,

                    ItemsSource = list,
                    
                    ItemTemplate = new DataTemplate(() =>
                    {
                        Label hourLabel = new Label();
                        hourLabel.SetBinding(Label.TextProperty, "van_uur");

                        Label roomLabel = new Label();
                        roomLabel.SetBinding(Label.TextProperty, "lokaal");

                        Label groupLabel = new Label();
                        groupLabel.SetBinding(Label.TextProperty, "klas");

                        Label lectureLabel = new Label();
                        lectureLabel.SetBinding(Label.TextProperty, "olod");

                        Label teacherLabel = new Label();
                        teacherLabel.SetBinding(Label.TextProperty, "docent");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Padding = new Thickness(0, 5),
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            hourLabel, roomLabel, groupLabel, lectureLabel, teacherLabel
                                        }
                                    }
                                }
                            }
                        };
                    })
                };

                // Build the page
                this.Content = listView;
            }
        }
    }
}
