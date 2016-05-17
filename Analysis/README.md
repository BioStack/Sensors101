# Analysis

The following contains a walkthrough for doing basic data analysis of several of the sensors.

### Prereqs

If doing on your own machine, you'll need to install [R](https://www.r-project.org/) and have a c/c++ dependecies such as clang/gcc/make.

Then, get files for this workshop.

```console
git clone https://github.com/BioStack/Sensors101
cd Sensors101/Analysis
```

Finally, install dependencies (or using RStudio).

```console
Rscript install.R
```

### EDA

The template code already reads the signal file from a command line argument or uses a default file. Let's add code to plot it.

```r
# Draw original signal
plot(edaSignal, col="green")
```
A Rplots.pdf will be created. You can open using  `open Rplots.pdf` (Mac) or `start Rplots.pdf` (Windows).

![image](https://cloud.githubusercontent.com/assets/742934/15330758/3e73056e-1c2c-11e6-850a-0999e95bcf95.png)

### Phasic and Tonic EDA

Like many biological systems, the [electrodermal system](http://dornsife.usc.edu/assets/sites/585/docs/handbookchapter2000.pdf) exhibits two different temporal responses.
The **phasic** component is a high-frequency, event-related response, whereas the **tonic** component is a low-frequency response.

We are typically interested in the phasic component if we're studying responses to specific events and tonic component for understanding general mood. The tonic component is generally considered to change every 20 seconds (0.05 Hz), whereas phasic components occur at much faster rates.

##### Building a filter

We can use a butterworth filter design to build a high-pass and low-pass filter. Basically, this allows us seperate our signal into a phasic and tonic component.

```r
# Construct a low and high-pass filter using a butterworth filter design.
bf_low <- butter(2, 1/20, type="low")
bf_high <- butter(2, 1/20, type="high")
```

Let's apply the filter on the edaSignal.

```r
phasic <- signal:::filter(bf_high, edaSignal)
tonic <- signal:::filter(bf_low, edaSignal)
```

##### Plotting the components.

```r
plot(tonic)
plot(phasic)
```

You'll notice that the tonic part of the signal will make larger changes in amplititude, whereas, the phasic component will have many peaks. Phasic signals can occur naturally several times a minute.

##### Finding peaks

A common task you'll want to perform is to identify event-related responses within the phasic component.
This problem is referred to as a "peak finding". Peak finding can actually be fairly difficult, especially with a fast changing signal with noise. Here, we will use a wavelet-based technique to help locate peaks.

```r
# Get Continuous Wavelet Transform of eda signal.
edaSignal.cwt <- wavCWT(phasic)
# tree
z <- wavCWTTree(edaSignal.cwt)
```

With the wavelet tree, we can use a peak finding algorithm:

```
# peaks (snr.min: the minimum allowed peak signal-to-noise ratio. Default: 3.)
p <- wavCWTPeaks(z,snr.min=0.1)
```

We have points of the peaks, but we want to be able to plot them on the original graph.

```r
plot(x, signal, type="l", xlab="time", ylab="phasic peaks")

peakX = x[attr(p, which="peaks")[,"iendtime"]]
peakY = phasic[attr(p, which="peaks")[,"iendtime"]]

points(x=peakX, y=peakY, pch=16, col="red", cex=1.2)
```

##### Other visualizations

We can visualize the wavelet.

```r
plot(edaSignal.cwt, series=TRUE)
plot(edaSignal.cwt, type="persp")
```
