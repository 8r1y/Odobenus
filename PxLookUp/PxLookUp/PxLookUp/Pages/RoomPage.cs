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
            this.Title = value;

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

            this.Children.Add(new DayPage(new ContentService().FilterCoursesByDay(list, 1))
            {
                Title = "Monday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterCoursesByDay(list, 2))
            {
                Title = "Tuesday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterCoursesByDay(list, 3))
            {
                Title = "Wednesday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterCoursesByDay(list, 4))
            {
                Title = "Thursday"
            });
            this.Children.Add(new DayPage(new ContentService().FilterCoursesByDay(list, 5))
            {
                Title = "Friday"
            });
        }

        public class DayPage : ContentPage
        {
            public DayPage(List<Course> list)
            {

                this.SetBinding(ContentPage.TitleProperty, "Name");

                Label hourLabel;
                Label roomLabel;
                Label groupLabel;
                Label lectureLabel;
                Label teacherLabel;

                Grid g = new Grid
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                    ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
                };

                g.Children.Add(hourLabel = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                },0,1,0,1);

                g.Children.Add(roomLabel = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                },0,1,1,2);

                g.Children.Add(groupLabel = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                },2,3,0,1);

                g.Children.Add(lectureLabel = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                },2,3,1,2);

                g.Children.Add(teacherLabel = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                },2,3,2,3);

                ListView listView = new ListView
                {                
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    RowHeight = 100,

                    ItemsSource = list,
                    
                    ItemTemplate = new DataTemplate(() =>
                    {                
                        hourLabel.SetBinding(Label.TextProperty, "van_uur");               
                        roomLabel.SetBinding(Label.TextProperty, "lokaal");                        
                        groupLabel.SetBinding(Label.TextProperty, "klas");                       
                        lectureLabel.SetBinding(Label.TextProperty, "olod");                       
                        teacherLabel.SetBinding(Label.TextProperty, "docent");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Padding = new Thickness(20, 5),
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    g                                                                  
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
