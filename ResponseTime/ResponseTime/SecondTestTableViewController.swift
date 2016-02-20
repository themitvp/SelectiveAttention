//
//  FirstTestTableViewController.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 17/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit

class SecondTestTableViewController: UITableViewController {
    
    @IBOutlet var table: UITableView!
    
    let section = ["Double click on image", "Click after image removed"]
    var itemsOne : [ClickItem] = []
    var itemsTwo : [Double] = []
    
    override func viewDidLoad() {
        super.viewDidLoad()
        if NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") != nil {
            let decoded  = NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") as! NSData
            itemsOne = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [ClickItem]
            
            table.reloadData()
        }
        if NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksTwo") != nil {
            itemsTwo = NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksTwo") as! [Double]
            table.reloadData()
        }
        
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    // MARK: - Table view data source
    override func tableView(tableView: UITableView, titleForHeaderInSection section: Int) -> String? {
        return self.section[section]
    }
    
    override func numberOfSectionsInTableView(tableView: UITableView) -> Int {
        return self.section.count
    }
    
    override func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        if section == 0
        {
            return itemsOne.count
        }else{
            return itemsTwo.count
        }
    }
    
    
    override func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCellWithIdentifier("cell", forIndexPath: indexPath)
        
        
        if indexPath.section == 0
        {
            let item = itemsOne[indexPath.row]
            cell.textLabel?.text = "Delay: \(item.delay) seconds, time: \(item.secondsBeforeClick) seconds"
        }else
        {
            let item = itemsTwo[indexPath.row]
            cell.textLabel?.text = "Delay: \(item) seconds"
        }
        
        return cell
    }
    override func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
        
        if editingStyle == UITableViewCellEditingStyle.Delete {
            if indexPath.section == 0
            {
                itemsOne.removeAtIndex(indexPath.row)
                
                let userDefaults = NSUserDefaults.standardUserDefaults()
                let encodedData = NSKeyedArchiver.archivedDataWithRootObject(itemsOne)
                userDefaults.setObject(encodedData, forKey: "TestTwoPerformance")
                userDefaults.synchronize()
                
                table.reloadData()
            }
            else{
                itemsTwo.removeAtIndex(indexPath.row)
                NSUserDefaults.standardUserDefaults().setObject(itemsTwo, forKey: "TestDoubleClicksTwo")
                
                table.reloadData()
            }
        }
    }
    /*
    // Override to support conditional editing of the table view.
    override func tableView(tableView: UITableView, canEditRowAtIndexPath indexPath: NSIndexPath) -> Bool {
    // Return false if you do not want the specified item to be editable.
    return true
    }
    */
    
    /*
    // Override to support editing the table view.
    override func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
    if editingStyle == .Delete {
    // Delete the row from the data source
    tableView.deleteRowsAtIndexPaths([indexPath], withRowAnimation: .Fade)
    } else if editingStyle == .Insert {
    // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
    }
    }
    */
    
    /*
    // Override to support rearranging the table view.
    override func tableView(tableView: UITableView, moveRowAtIndexPath fromIndexPath: NSIndexPath, toIndexPath: NSIndexPath) {
    
    }
    */
    
    /*
    // Override to support conditional rearranging of the table view.
    override func tableView(tableView: UITableView, canMoveRowAtIndexPath indexPath: NSIndexPath) -> Bool {
    // Return false if you do not want the item to be re-orderable.
    return true
    }
    */
    
    /*
    // MARK: - Navigation
    
    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
    // Get the new view controller using segue.destinationViewController.
    // Pass the selected object to the new view controller.
    }
    */
    
}

