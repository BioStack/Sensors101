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

![image](https://cloud.githubusercontent.com/assets/742934/15330758/3e73056e-1c2c-11e6-850a-0999e95bcf95.png)

### Phasic and Tonic EDA

Like many biological systems, the [electrodermal system](http://dornsife.usc.edu/assets/sites/585/docs/handbookchapter2000.pdf) exhibits two different temporal responses.
The **phasic** component is a high-frequency, event-related response, whereas the **tonic** component is a low-frequency response.

We are typically interested in the phasic component if we're studying responses to specific events and tonic component for understanding general mood. The tonic component is generally considered to change every 20 seconds (0.05 Hz), whereas phasic components occur at much faster rates.

##### Building a filter




