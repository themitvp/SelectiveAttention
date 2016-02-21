//
//  ResultViewController.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 17/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit

class ResultViewController: UIViewController {

    @IBOutlet weak var firsteAverage: UILabel!
    @IBOutlet weak var secondAverage: UILabel!
    @IBOutlet weak var thirdAverage: UILabel!
    
    var resultsOne : [ClickItem] = []
    var resultsTwo : [ClickItem] = []
    var resultThird : [Double] = []

    override func viewDidLoad() {
        super.viewDidLoad()

        if NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") != nil {
            let decoded  = NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") as! NSData
            resultsTwo = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [ClickItem]
            
            var totalDelay = 0.0
            for item in resultsTwo{
                totalDelay += item.delay
            }
            let average = totalDelay / Double(resultsTwo.count)
            secondAverage.text = "Average: \(average)"
        }
        if NSUserDefaults.standardUserDefaults().objectForKey("TestOnePerformance") != nil {
            let decoded  = NSUserDefaults.standardUserDefaults().objectForKey("TestOnePerformance") as! NSData
            resultsOne = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [ClickItem]
            
            var totalDelay = 0.0
            for item in resultsOne{
                totalDelay += item.delay
            }
            let average = totalDelay / Double(resultsOne.count)
            firsteAverage.text = "Average: \(average)"
        }
        if NSUserDefaults.standardUserDefaults().objectForKey("TestThirdPerformance") != nil {
            resultThird = NSUserDefaults.standardUserDefaults().objectForKey("TestThirdPerformance") as! [Double]
            
            var totalDelay = 0.0
            for item in resultThird{
                totalDelay += item
            }
            let average = totalDelay / Double(resultThird.count)
            thirdAverage.text = "Average: \(average)"
        }
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
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
