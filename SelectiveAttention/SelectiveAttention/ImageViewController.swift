//
//  ImageViewController.swift
//  SelectiveAttention
//
//  Created by Jesper Østergaard on 10/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

/*
Punkter:
    (342.666661580404, 134.999989827474) : Gelænder
    (3.999989827474, 88.9999898274739) : Personer
    (105.999989827474, 57.3333333333333)  :Kirke
    (224.999989827474, 3.99998982747394) : Grene
    (133.999989827474, 227.333333333333) : Fliser
    (270.999989827474, 233.333333333333) : Fliser ved græs
*/

import UIKit

class ImageViewController: UIViewController {
    
    var time = 0
    var numberOfSwitches = 0
    var currentTag = 10
    var selectedPoints = [Int: SelectedPoint]()
    
    var showingModified = true
    var isDone = false
    
    var imageName = "original"
    
    var timer = NSTimer()
    
    var correctPoints = [
        CGPoint(x:342.666661580404, y:134.999989827474),
        CGPoint(x:3.999989827474, y:88.9999898274739),
        CGPoint(x:105.999989827474, y:57.3333333333333),
        CGPoint(x:224.999989827474, y:3.99998982747394),
        CGPoint(x:133.999989827474, y:227.333333333333),
        CGPoint(x: 270.999989827474, y: 233.333333333333)
    ]
    
    var performanceHistory = [PerformanceHistory]() //Holding the saved data.
    
    @IBOutlet weak var imageView: UIImageView!
    @IBOutlet weak var doneBtn: UIBarButtonItem!
    @IBOutlet weak var changeImageBtn: UIBarButtonItem!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        //Load saved data
        if NSUserDefaults.standardUserDefaults().objectForKey("TestPerformanceHistoryCustom") != nil {
            
            let decoded = NSUserDefaults.standardUserDefaults().objectForKey("TestPerformanceHistoryCustom") as! NSData
            performanceHistory = NSKeyedUnarchiver.unarchiveObjectWithData(decoded) as! [PerformanceHistory]
        }
        
        
        //Set long pressed gesture recosnizer on the image.
        let longPressRecognizer = UILongPressGestureRecognizer(target:self, action:Selector("imageLongPressed:"))
        imageView.userInteractionEnabled = true
        imageView.addGestureRecognizer(longPressRecognizer)
        
        //Time to get the time used.
        timer = NSTimer.scheduledTimerWithTimeInterval(1, target: self, selector: Selector("increaseTimer"), userInfo: nil, repeats: true)
    }

    func increaseTimer() {
        time++
    }
    
    //Method to change the image (Switch between manipuleted and original image)
    @IBAction func ChangeImage(sender: AnyObject) {
        if isDone == false {
            numberOfSwitches += 1
            
            imageName = "original"
            changeImageBtn.title = "See manipulated"
            
            if showingModified == false {
                imageName = "manipulated"
                changeImageBtn.title = "See original"
            }
            
            for (tag, _) in selectedPoints {
                if let imageViewTemp = view.viewWithTag(tag) as? UIImageView {
                    imageViewTemp.image = nil
                }
            }
            
            showingModified = !showingModified
            
            imageView.image = nil
            
            //Set a delay on 2 seconds before switching to the next image.
            let _ : NSTimer = NSTimer.scheduledTimerWithTimeInterval(2, target: self, selector: Selector("delayedCode"), userInfo: nil, repeats: false)
        }
    }
    func delayedCode() {
        
        //Show the new image.
        imageView.image = UIImage(named: imageName)
        
        var image:UIImage?
        if showingModified == true {
            image = UIImage(named: "orange_circle.png")!
            
        }
        
        for (tag, _) in selectedPoints {
            if let imageViewTemp = view.viewWithTag(tag) as? UIImageView {
                imageViewTemp.image = image
            }
        }
    }
    
    //Method to handle when the user is done.
    @IBAction func doneSelection(sender: AnyObject) {
        
        isDone = true
        doneBtn.enabled = false
        changeImageBtn.enabled = false
        timer.invalidate()
        
        var numberOfCorrect = 0
        //Calculate number of correct items.
        for (tag, value) in selectedPoints {
            if let imageViewTemp = view.viewWithTag(tag) as? UIImageView {
                
                var imagePath = "red.png"
                
                for point in correctPoints {
                    let distance = hypot(CGFloat(value.xCoordinate) - point.x, CGFloat(value.yCoordinate) - point.y)
                    if distance < 40{
                        imagePath = "green.png"
                        numberOfCorrect += 1
                    }
                }
                
                let image = UIImage(named: imagePath)
                imageViewTemp.image = image!
            }
        }
        
        //save data
        let date = NSDate()
        var temp_points = [SelectedPoint]()
        for (tag, value) in selectedPoints{
            temp_points.append(SelectedPoint(tagId: tag, selectedAfterTime: value.selectedAfterTime, xCoordinate: value.xCoordinate, yCoordinate: value.yCoordinate))
        }
        let new_performance = PerformanceHistory(date: date, totalTime: time, switches: numberOfSwitches, correct: numberOfCorrect, selectedPoints: temp_points)
        performanceHistory.append(new_performance)
        
        let userDefaults = NSUserDefaults.standardUserDefaults()
        let encodedData = NSKeyedArchiver.archivedDataWithRootObject(performanceHistory)
        userDefaults.setObject(encodedData, forKey: "TestPerformanceHistoryCustom")
        userDefaults.synchronize()
        
        //NSUserDefaults.standardUserDefaults().setObject(performanceHistory, forKey: "TestPerformanceHistory")
        
        
        //Show alert box
        let alert = UIAlertController(title: "Result", message: "You had \(numberOfCorrect) out of \(correctPoints.count) correct, and your time was \(time) seconds", preferredStyle: UIAlertControllerStyle.Alert)
        alert.addAction(UIAlertAction(title: "OK", style: .Default, handler: { (action) -> Void in
            
            //self.dismissViewControllerAnimated(true, completion: nil)
            
        }))
        
        self.presentViewController(alert, animated: true, completion: nil)
    }
    
    
    func imageLongPressed(sender: UILongPressGestureRecognizer)
    {
        if(sender.state == UIGestureRecognizerState.Began && isDone == false && showingModified == true){
            
            let location = sender.locationInView(sender.view) //Use the imageview as the view.
            
            let imageName = "orange_circle.png"
            let image = UIImage(named: imageName)
            let newImageView = UIImageView(image: image!)

            newImageView.frame = CGRect(x: location.x-20, y: location.y-20, width: 40, height: 40)
            newImageView.tag = currentTag
            
            let pressRecognizer = UITapGestureRecognizer(target:self, action:Selector("removeCircle:"))
            let panGesture = UIPanGestureRecognizer(target: self, action: Selector("wasDragged:"))
            
            newImageView.userInteractionEnabled = true
            newImageView.addGestureRecognizer(pressRecognizer)
            newImageView.addGestureRecognizer(panGesture)
            
            sender.view!.addSubview(newImageView)

            selectedPoints[currentTag] = SelectedPoint(tagId: currentTag, selectedAfterTime: time, xCoordinate: Float(location.x - 20), yCoordinate: Float(location.y-20))
            
            currentTag += 1
            
            
        }
    }
    
    //Method to handle the dragging of an image
    var dragStartPositionRelativeToCenter : CGPoint?
    
    func wasDragged(gesture: UIPanGestureRecognizer) {
        if isDone == false && showingModified == true{
            let draggedImage = gesture.view!
            let translation = gesture.translationInView(self.imageView) //Difference from the starting point.
            
            if gesture.state == UIGestureRecognizerState.Began {
                //Set starting point for the image
                dragStartPositionRelativeToCenter = CGPoint(x: draggedImage.center.x, y: draggedImage.center.y)
            }
            
            draggedImage.center = CGPoint(x: (dragStartPositionRelativeToCenter?.x)! + translation.x, y: (dragStartPositionRelativeToCenter?.y)! + translation.y)
            
            if gesture.state == UIGestureRecognizerState.Ended {
                dragStartPositionRelativeToCenter = nil
            }
            //selectedPoints[draggedImage.tag] = CGPoint(x: draggedImage.center.x, y: draggedImage.center.y)
            selectedPoints[draggedImage.tag] = SelectedPoint(tagId: draggedImage.tag, selectedAfterTime: time, xCoordinate: Float(draggedImage.center.x), yCoordinate: Float(draggedImage.center.y))
        }
    }
    
    //Function to remove a circle when clicked.
    func removeCircle(sender: UILongPressGestureRecognizer)
    {
        if isDone == false && showingModified == true {
            if let imageViewClicked = sender.view as? UIImageView {
                imageViewClicked.removeFromSuperview()
                selectedPoints.removeValueForKey(imageViewClicked.tag)
            }
        }
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
}
