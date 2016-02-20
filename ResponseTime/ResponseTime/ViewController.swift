//
//  ViewController.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 17/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

/*
Notes to what could be improved:
- Save reaction time
- Save click after change (Save last image as variable to see it the user clicked just after the image was changed)
- Graphs
- Play around with the graph framework:

*/

import UIKit

class ViewController: UIViewController {

    //Buttons
    var buttonTags = [11,12,13,14,15,16,17,18,19]
    //POssible delays. Select random in each round.
    var possibleDelays = [0.05, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2]
    //If we have a delay waiting
    var delayWaiting = false
    //Time before delayed started to the user clicked the button again.
    var time = 0.0
    //Dealy in seconds
    var waitSeconds = 0.0
    var timer = NSTimer()
    var selectedTag = 0
    
    var lastButtonTag = 0
    var lastDelay = 0.0
    
    //saved data
    var savedData : [ClickItem] = []
    var doubleClick : [Double] = []
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        //Load data
        if NSUserDefaults.standardUserDefaults().objectForKey("TestOnePerformance") != nil {
            let decoded  = NSUserDefaults.standardUserDefaults().objectForKey("TestOnePerformance") as! NSData
            savedData = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [ClickItem]
        }
        if NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksOne") != nil {
            doubleClick = NSUserDefaults.standardUserDefaults().objectForKey("TestDoubleClicksOne") as! [Double]
        }
        
        setVisibleButton()
        // Do any additional setup after loading the view, typically from a nib.
    }

    @IBAction func testAction(sender: AnyObject) {
        print(CGFloat(Float(arc4random()) / Float(UINT32_MAX)))
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    func setVisibleButton(){
        
        lastDelay = waitSeconds
        lastButtonTag = selectedTag
        
        timer.invalidate()
        //waitSeconds = Double(CGFloat(Float(arc4random()) / Float(UINT32_MAX)))
        waitSeconds = possibleDelays.randomItem()
        time = 0
        delayWaiting = false
        
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

    func increaseTimer() {
        time += 0.01
    }
    
    @IBAction func buttonClicked(sender: UIButton) {
        if sender.tag == selectedTag {
            if delayWaiting{
                //Create new record
                let newRecord = ClickItem(delay: waitSeconds, secondsBeforeClick: time, username: "", date : NSDate())
                savedData.append(newRecord)
                
                //Save the record
                let userDefaults = NSUserDefaults.standardUserDefaults()
                let encodedData = NSKeyedArchiver.archivedDataWithRootObject(savedData)
                userDefaults.setObject(encodedData, forKey: "TestOnePerformance")
                userDefaults.synchronize()
                
                print("Clicked when the button was visible")
            }else{
                
                delayWaiting = true
                
                timer = NSTimer.scheduledTimerWithTimeInterval(0.01, target: self, selector: Selector("increaseTimer"), userInfo: nil, repeats: true)
                
                let delay = waitSeconds * Double(NSEC_PER_SEC)  // nanoseconds per seconds
                let dispatchTime = dispatch_time(DISPATCH_TIME_NOW, Int64(delay))
                
                dispatch_after(dispatchTime, dispatch_get_main_queue(), {
                    sender.setImage(nil, forState: .Normal)
                    self.setVisibleButton()
                })
            }
        }else if sender.tag == lastButtonTag { //User clicked again on the last button just after it has been removed.
            print(lastDelay)
            doubleClick.append(lastDelay)
            NSUserDefaults.standardUserDefaults().setObject(doubleClick, forKey: "TestDoubleClicksOne")
        }
    }

}

extension Array {
    func randomItem() -> Element {
        let index = Int(arc4random_uniform(UInt32(self.count)))
        return self[index]
    }
}