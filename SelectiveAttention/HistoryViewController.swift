//
//  HistoryViewController.swift
//  SelectiveAttention
//
//  Created by Jesper Østergaard on 12/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit

class HistoryViewController: UIViewController, UITableViewDelegate {
    var performanceHistory = [PerformanceHistory]()
    
    @IBOutlet weak var historyTable: UITableView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        //Load saved data
        if NSUserDefaults.standardUserDefaults().objectForKey("TestPerformanceHistoryCustom") != nil {
            
            let decoded = NSUserDefaults.standardUserDefaults().objectForKey("TestPerformanceHistoryCustom") as! NSData
            performanceHistory = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [PerformanceHistory]
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

        let item = performanceHistory[indexPath.row]
        
        cell.dateLabel?.text = "\(item.date)"
        cell.timeLabel?.text = "\(item.totalTime) seconds"
        cell.switchesLabel?.text = "\(item.switches)"
        cell.correctLabel?.text = "\(item.correct)"
        return cell
        
    }
    func tableView(tableView: UITableView, commitEditingStyle editingStyle: UITableViewCellEditingStyle, forRowAtIndexPath indexPath: NSIndexPath) {
        
        if editingStyle == UITableViewCellEditingStyle.Delete {
            
            performanceHistory.removeAtIndex(indexPath.row)
            
            let userDefaults = NSUserDefaults.standardUserDefaults()
            let encodedData = NSKeyedArchiver.archivedDataWithRootObject(performanceHistory)
            userDefaults.setObject(encodedData, forKey: "TestPerformanceHistoryCustom")
            userDefaults.synchronize()
            
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
