//
//  HistoryViewController.swift
//  SelectiveAttention
//
//  Created by Jesper Østergaard on 12/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit

class HistoryViewController: UIViewController, UITableViewDelegate {
    var performanceHistory = [[String  : String ]]()
    
    @IBOutlet weak var historyTable: UITableView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        if NSUserDefaults.standardUserDefaults().objectForKey("TestPerformanceHistory") != nil {
            
            performanceHistory = NSUserDefaults.standardUserDefaults().objectForKey("TestPerformanceHistory") as! [[String  : String ]]
            historyTable.reloadData()
            print(performanceHistory)
            
        }
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return performanceHistory.count
    }
    func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        
        
        
        //let cell = UITableViewCell(style: UITableViewCellStyle.Default, reuseIdentifier: "Cell")
        let cell = tableView.dequeueReusableCellWithIdentifier("Cell", forIndexPath: indexPath) as! HistoryTableViewCell
        
        cell.dateLabel?.text = performanceHistory[indexPath.row]["date"]
        cell.timeLabel?.text = performanceHistory[indexPath.row]["seconds"]! + " seconds"
        cell.switchesLabel?.text = performanceHistory[indexPath.row]["switches"]
        cell.correctLabel?.text = performanceHistory[indexPath.row]["correct"]
        
        return cell
        
    }
    func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
        
        if editingStyle == UITableViewCellEditingStyle.Delete {
            
            performanceHistory.removeAtIndex(indexPath.row)
            
            NSUserDefaults.standardUserDefaults().setObject(performanceHistory, forKey: "TestPerformanceHistory")
            
            historyTable.reloadData()
        }
        
        
        
    }
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
