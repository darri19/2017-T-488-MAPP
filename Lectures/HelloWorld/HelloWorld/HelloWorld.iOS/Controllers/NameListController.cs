﻿using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace HelloWorld.iOS.Controllers
{
    public class NameListController : UITableViewController
    {
        private readonly List<Person> _personList;

        public NameListController(List<Person> personList)
        {
            this._personList = personList;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "Name list";

            this.TableView.Source = new NameListDataSource(this._personList, _onSelectedPerson);
        }

        private void _onSelectedPerson(int row)
        {
            var okAlertController = UIAlertController.Create("Person selected", this._personList[row].Name,
                UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            this.PresentViewController(okAlertController, true, null);
        }
    }
}
