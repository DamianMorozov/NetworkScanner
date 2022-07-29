// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetworkLib.Core;
using NetworkLib.Core.Objects;

namespace NetworkLibTests
{
    [TestFixture]
    public class ScannerTests
    {
        [Test()]
        public void Scan_WithInvalidIp_IsNotEqual()
        {
            // Arrange.
            Scanner scan = new();
            scan.ScanProgressChanged += ScanProgressChangedWithInvalidIp;
            scan.ScanComplete += ScanCompleteWithInvalidIp;

            // Act.
            IpScanObject expected = new("N/A", 0, "N/A", "N/A", null, false);
            IpScanObject actual = scan.Scan("x.x.x.x");

            // Assert.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test()]
        public void Scan_WithValidIp_IsNotEqual()
        {
            // Arrange.
            Scanner scan = new();
            //scan.ScanProgressChanged += Scan_ProgressChanged_With_Invalid_IP;
            scan.ScanComplete += ScanCompleteWithValidIp;

            // Act.
            IpScanObject expected = new("N/A", 0, "N/A", "N/A", null, false);
            IpScanObject actual = scan.Scan("x.x.x.x");

            // Assert.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test()]
        public void ScanRange_WithInvalidIpAddressRange_IsNotEqual()
        {
            // Arrange.
            Scanner scan = new();
            //var scan1 = new Substitute.For<IScanner>();

            scan.ScanRangeProgressChanged += ScanRangeProgressChangedWithInvalidIpAddressRange;
            scan.ScanRangeComplete += ScanRangeCompleteWithInvalidIpAddressRange;

            // Act.
            List<IpScanObject> expected = new();
            List<IpScanObject> actual = scan.ScanRange("x.x.x.x", "y.y.y.y");

            // Assert.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test()]
        public void ScanList_WithInvalidList_IsNotEqual()
        {
            // Arrange.
            Scanner scan = new();
            scan.ScanListProgressChanged += ScanListProgressChangedWithInvalidList;
            scan.ScanListComplete += ScanListCompleteWithInvalidList;

            // Act.
            List<IpScanObject> expected = new();
            List<IpScanObject> actual = scan.ScanList("x.x.x.x, y.y.y.y, z.z.z.z");

            // Assert.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test()]
        public void PortKnock_WithInvalidIp_IsNotEqual()
        {
            // Arrange.
            Scanner scan = new();
            scan.PortKnockProgressChanged += PortKnockProgressChangedWithInvalidIp;
            scan.PortKnockComplete += PortKnockCompleteWithInvalidIp;

            // Act.
            PkScanObject expected = new();
            PkScanObject actual = scan.PortKnock("x.x.x.x");

            // Assert.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test()]
        public void PortKnockRange_WithInvalidIpAddressRange_IsNotEqual()
        {
            // Arrange.
            Scanner scan = new();
            scan.PortKnockRangeProgressChanged += PortKnockRangeProgressChangedWithInvalidIpAddressRange;
            scan.PortKnockRangeComplete += PortKnockRangeCompleteWithInvalidIpAddressRange;

            // Act.
            List<PkScanObject> expected = new();
            List<PkScanObject> actual = scan.PortKnockRange("x.x.x.x", "y.y.y.y");

            // Assert.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test()]
        public void PortKnockList_WithInvalidIpAddressRange_IsNotEqual()
        {
            // Arrange.
            Scanner scan = new();
            scan.PortKnockListProgressChanged += PortKnockListProgressChangedWithInvalidList;
            scan.PortKnockListComplete += PortKnockListCompleteWithInvalidList;

            // Act.
            List<PkScanObject> expected = new();
            List<PkScanObject> actual = scan.PortKnockList("x.x.x.x, y.y.y.y, z.z.z.z");

            // Assert.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void ScanCompleteWithInvalidIp(object sender, ScanCompleteEventArgs e)
        {
            // Actual should be a default shell.
            IpScanObject expected = new("N/A", 0, "N/A", "N/A", null, false);
            IpScanObject actual = e.Result;

            // Make sure we get what we want.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void ScanCompleteWithValidIp(object sender, ScanCompleteEventArgs e)
        {
            // Actual should be a default shell.
            IpScanObject expected = new("N/A", 0, "N/A", "N/A", null, false);
            IpScanObject actual = e.Result;

            // Make sure we get what we want.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void ScanRangeCompleteWithInvalidIpAddressRange(object sender, ScanRangeCompleteEventArgs e)
        {
            // Actual should be a blank list.
            List<IpScanObject> expected = new();
            List<IpScanObject> actual = e.Results;

            // Make sure we get what we want.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void ScanListCompleteWithInvalidList(object sender, ScanListCompleteEventArgs e)
        {
            // Actual should be a blank list.
            List<IpScanObject> expected = new();
            List<IpScanObject> actual = e.Results;

            // Make sure we get what we want.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void PortKnockCompleteWithInvalidIp(object sender, PortKnockCompleteEventArgs e)
        {
            // Actual should be a blank object.
            PkScanObject expected = new();
            PkScanObject actual = e.Result;

            // Make sure we get what we want.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void PortKnockRangeCompleteWithInvalidIpAddressRange(object sender, PortKnockRangeCompleteEventArgs e)
        {
            // Actual should be a blank list.
            List<PkScanObject> expected = new();
            List<PkScanObject> actual = e.Results;

            // Make sure we get what we want.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void PortKnockListCompleteWithInvalidList(object sender, PortKnockListCompleteEventArgs e)
        {
            // Actual should be a blank list.
            List<PkScanObject> expected = new();
            List<PkScanObject> actual = e.Results;

            // Make sure we get what we want.
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        public void ScanProgressChangedWithInvalidIp(object sender, ScanProgressChangedEventArgs e) { }

        public void ScanRangeProgressChangedWithInvalidIpAddressRange(object sender, ScanRangeProgressChangedEventArgs e) { }

        public void ScanListProgressChangedWithInvalidList(object sender, ScanListProgressChangedEventArgs e) { }

        public void PortKnockProgressChangedWithInvalidIp(object sender, PortKnockProgressChangedEventArgs e) { }

        public void PortKnockRangeProgressChangedWithInvalidIpAddressRange(object sender, PortKnockRangeProgressChangedEventArgs e) { }

        public void PortKnockListProgressChangedWithInvalidList(object sender, PortKnockListProgressChangedEventArgs e) { }
    }
}
