//
//  SecondTestViewController.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 17/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit

class SecondTestViewController: UIViewController {

    
    var buttonTags = [11,12,13,14,15,16,17,18,19]
    var delayWaiting = false
    var time = 0.0
    var waitSeconds = 0.1
    var timer = NSTimer()
    var selectedTag = 0
    var numberBeforeDealy = 0
    var possibleRoundsBeforeDealy = [2,3,4,5,6]
    
    
    var lastButtonTag = 0
    var lastDelay = 0.0
    
    //saved data
    var savedData : [ClickItem] = []
    var doubleClick : [Double] = []
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        if NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksTwo") != nil {
            doubleClick = NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksTwo") as! [Double]
        }
        
        //Load data
        if NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") != nil {
            let decoded  = NSUserDefaults.standardUserDefaults().objectForKey("TestTwoPerformance") as! NSData
            savedData = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [ClickItem]
        }
        
        numberBeforeDealy = possibleRoundsBeforeDealy.randomItem()
        setVisibleButton()
        print("Rounds before delay: \(numberBeforeDealy)")
        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    func increaseTimer() {
        time += 0.01
    }
    func setVisibleButton(){
        timer.invalidate()
        time = 0
        delayWaiting = false
        
        lastButtonTag = selectedTag
        
        var button_tag = buttonTags.randomItem()
        if button_tag == selectedTag {
            if button_tag == 19{
                button_tag = 18
            }else{
                button_tag = button_tag + 1
            }
        }
        selectedTag = button_tag
        
        if let tmpButton = self.view.viewWithTag(button_tag) as? UIButton {
            tmpButton.setImage(UIImage(named: "nought.png"), forState: .Normal)
        }
    }
    
    
    @IBAction func buttonClicked(sender: UIButton) {
        if sender.tag == selectedTag {
            if delayWaiting{
                
                //Create new record
                print(waitSeconds)
                let newRecord = ClickItem(delay: waitSeconds, secondsBeforeClick: time, username: "", date : NSDate())
                savedData.append(newRecord)
                
                //Save the record
                let userDefaults = NSUserDefaults.standardUserDefaults()
                let encodedData = NSKeyedArchiver.archivedDataWithRootObject(savedData)
                userDefaults.setObject(encodedData, forKey: "TestTwoPerformance")
                userDefaults.synchronize()
                
                print("Clicked when the button was visible")
            }else{
                
                delayWaiting = true
                timer = NSTimer.scheduledTimerWithTimeInterval(0.01, target: self, selector: Selector("increaseTimer"), userInfo: nil, repeats: true)
                
                numberBeforeDealy -= 1
                
                if numberBeforeDealy == 0 {
                    lastDelay = waitSeconds
                    let delay = waitSeconds * Double(NSEC_PER_SEC)  // nanoseconds per seconds
                    let dispatchTime = dispatch_time(DISPATCH_TIME_NOW, Int64(delay))
                    dispatch_after(dispatchTime, dispatch_get_main_queue(), {
                        sender.setImage(nil, forState: .Normal)
                        self.waitSeconds = self.waitSeconds + 0.1
                        self.numberBeforeDealy = self.possibleRoundsBeforeDealy.randomItem()
                        self.setVisibleButton()
                    })
                }else {
                    //print("QUICK \(numberBeforeDealy)")
                    sender.setImage(nil, forState: .Normal)
                    setVisibleButton()
                }
            }
        }else if sender.tag == lastButtonTag { //User clicked again on the last button just after it has been removed.
            doubleClick.append(lastDelay)
            NSUserDefaults.standardUserDefaults().setObject(doubleClick, forKey: "TestDoubleClicksTwo")
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
